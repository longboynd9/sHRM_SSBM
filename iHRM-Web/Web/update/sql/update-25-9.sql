
CREATE TABLE [dbo].[tbSaveData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](20) NOT NULL,
	[data] [ntext] NULL,
 CONSTRAINT [PK_tbSaveData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


CREATE PROC [dbo].[p_SaveData_Get]
	@code VARCHAR(20)
AS
SET NOCOUNT ON

SELECT data
FROM dbo.tbSaveData
WHERE code = @code
GO


CREATE PROC [dbo].[p_SaveData_Set]
	@code VARCHAR(20),
	@data NTEXT
AS
SET NOCOUNT ON

UPDATE dbo.tbSaveData
SET data = @data
WHERE code = @code

IF @@ROWCOUNT = 0
INSERT dbo.tbSaveData
        ( code, data )
VALUES  ( @code, -- code - varchar(20)
          @data  -- data - ntext
          )
GO




ALTER PROC [dbo].[p_chamcong_CaNhan_DangKyCaLam_tapThe]
	@maTapThe NVARCHAR(15) = NULL,
	@ngay DATETIME,
	@idCaLam UNIQUEIDENTIFIER,
	@dkLamThem INT = NULL,
	@hsLuong INT = NULL
AS

DECLARE @depIDs TABLE(id NVARCHAR(10))
INSERT @depIDs( id )
VALUES (@maTapThe)

INSERT @depIDs( id )
SELECT d.DepID
FROM dbo.tblRef_Department d
WHERE ISNULL(d.DepParent,'') = ISNULL(@maTapThe,'')

INSERT @depIDs( id )
SELECT d.DepID
FROM dbo.tblRef_Department d
	INNER JOIN @depIDs dd ON d.DepParent = dd.id
WHERE dd.id != @maTapThe

UPDATE dbo.tbKetQuaQuetThe
SET idCaLam = @idCaLam,
	dkLamThem = @dkLamThem,
	heSoLuong = @hsLuong
FROM tbKetQuaQuetThe k
	INNER JOIN dbo.tblEmployee e ON k.EmployeeID = e.EmployeeID AND k.ngay = @ngay
	INNER JOIN @depIDs d ON e.DepID = d.id

INSERT dbo.tbKetQuaQuetThe
        ( id ,
          EmployeeID ,
          CardID ,
          ngay ,
          idCaLam ,
          trangThai ,
          tgQuetDen ,
          tgQuetVe ,
          tgDiMuon ,
          tgVeSom ,
          dkLamThem ,
          heSoLuong
        )
SELECT    NEWID() , -- id - uniqueidentifier
          e.EmployeeID , -- EmployeeID - varchar(20)
          e.CardID , -- CardID - nvarchar(14)
          @ngay , -- ngay - date
          @idCaLam , -- idCaLam - uniqueidentifier
          0 , -- trangThai - int
          NULL , -- tgQuetDen - time
          NULL , -- tgQuetVe - time
          NULL , -- tgDiMuon - int
          NULL , -- tgVeSom - int
          @dkLamThem , -- dkLamThem - int
          @hsLuong  -- heSoLuong - int
FROM dbo.tblEmployee e
	LEFT JOIN tbKetQuaQuetThe kq ON e.EmployeeID = kq.EmployeeID AND kq.ngay = @ngay
	INNER JOIN @depIDs d ON e.DepID = d.id
WHERE ISNULL(e.IsNotOT,0)=0
	AND kq.id IS NULL


GO

CREATE TYPE [dbo].[Lst_Date] AS TABLE(
	[d] [datetime] NULL
)
GO
CREATE  FUNCTION fn_Split(@text varchar(8000), @delimiter varchar(20) = ' ')
RETURNS @Strings TABLE
(   
  position int IDENTITY PRIMARY KEY,
  value varchar(8000)  
)
AS
BEGIN

DECLARE @index int
SET @index = -1

WHILE (LEN(@text) > 0)
  BEGIN 
    SET @index = CHARINDEX(@delimiter , @text) 
    IF (@index = 0) AND (LEN(@text) > 0) 
      BEGIN  
        INSERT INTO @Strings VALUES (@text)
          BREAK 
      END 
    IF (@index > 1) 
      BEGIN  
        INSERT INTO @Strings VALUES (LEFT(@text, @index - 1))  
        SET @text = RIGHT(@text, (LEN(@text) - @index)) 
      END 
    ELSE
      SET @text = RIGHT(@text, (LEN(@text) - @index))
    END
  RETURN
END
go
ALTER PROC [dbo].[p_tblEmployee_GetAll]
	@SearchKey NVARCHAR(255) = NULL,
	@phongban NVARCHAR(200) = '',
	@OrderBy NVARCHAR(128) = NULL,
	@Page INT = 1,
	@PageSize INT = 10,
	@RecordCount INT OUTPUT
AS
declare @Key nvarchar(150)
set @key =UPPER(dbo.fChuyenCoDauThanhKhongDau(@SearchKey))
SET NOCOUNT ON
	
SELECT *
FROM (
	SELECT 
		ROW_NUMBER() OVER (ORDER BY EmployeeCode) RowNum,
		[EmployeeID], 
		[EmployeeCode], 
		[EmployeeName], 
		[EmployeeName_Eng], 
		AppliedDate,
		EmpTypeID,
		EmpTypeName,
		Address,
		DepID,
		DepName,
		e.PosID,
		e.PosName,
		e.Birthday, e.Phone, e.IDCard,e.SexID,e.BankAccount,e.CardID,e.BasicSalary,e.IssuePlace,e.RegularAllowance,e.NativeCountry,e.NationalityName
	FROM tblEmployee e
	WHERE (ISNULL(@phongban,'')='' or DepID in(SELECT Value FROM fn_Split(@phongban, ','))) and (ISNULL(@SearchKey,'')='' OR EmployeeCode=@SearchKey OR EmployeeID=@SearchKey OR NameSearch LIKE '%'+ @key+'%')
) t
WHERE t.RowNum > (@Page-1)*@PageSize AND t.RowNum <= @Page*@PageSize

SET @RecordCount = (
	SELECT COUNT(*)
	FROM tblEmployee	
	WHERE (ISNULL(@phongban,'')='' or DepID in(SELECT Value FROM fn_Split(@phongban, ','))) and  ( ISNULL(@SearchKey,'')='' OR EmployeeCode=@SearchKey OR EmployeeID=@SearchKey OR NameSearch LIKE '%'+ @key+'%')
)

ALTER TABLE [dbo].[tbDangKyVangMat]
ADD [coHuongLuong] [int] NOT NULL
GO

ALTER TABLE [dbo].[tbDangKyVangMat] ADD  CONSTRAINT [DF_tbDangKyVangMat_coHuongLuong]  DEFAULT ((0)) FOR [coHuongLuong]
GO



ALTER PROC [dbo].[p_chamcong_CaNhan_DangKyVangMat]
	@empID NVARCHAR(20),
	@ngay DATETIME,
	@tuGio TIME(0),
	@denGio TIME(0),
	@lyDo INT,
	@ghiChu NVARCHAR(255),
	@coHuongLuong INT = 1
AS

DECLARE @idKetQuaQuetThe UNIQUEIDENTIFIER
	
SELECT TOP 1 @idKetQuaQuetThe = id
FROM dbo.tbKetQuaQuetThe
WHERE EmployeeID = @empID AND ngay = @ngay

IF @idKetQuaQuetThe IS NULL
BEGIN
	PRINT N'Chýa ðãng k? ca làm'
	RETURN -1
END

UPDATE dbo.tbDangKyVangMat
SET tuGio = @tuGio,
	denGio = @denGio,
	lydo = @lyDo,
	ghiChu = @ghiChu,
	EmployeeID = @empID,
	coHuongLuong = @coHuongLuong
WHERE idKetQuaQuetThe = @idKetQuaQuetThe

IF @@ROWCOUNT = 0
	INSERT dbo.tbDangKyVangMat
	        ( id ,
	          idKetQuaQuetThe ,
	          tuGio ,
	          denGio ,
	          lydo ,
	          ghiChu ,
	          trangThaiQuetThe ,
	          EmployeeID,
	          coHuongLuong
	        )
	VALUES  ( NEWID() , -- id - uniqueidentifier
	          @idKetQuaQuetThe , -- idKetQuaQuetThe - uniqueidentifier
	          @tuGio , -- tuGio - time
	          @denGio , -- denGio - time
	          @lyDo , -- lydo - int
	          @ghiChu , -- ghiChu - nvarchar(255)
	          0 , -- trangThaiQuetThe - int
	          @empID,  -- EmployeeID - varchar(20)
	          @coHuongLuong
	        )
	        
RETURN 1


GO

CREATE TABLE [dbo].[tbPhuCapCoDinh](
	[id] [uniqueidentifier] NOT NULL,
	[employeeID] [varchar](15) NULL,
	[pc_XangXe] [float] NULL,
 CONSTRAINT [PK_tbPhuCapCoDinh] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE PROC p_tbPhuCapCoDinh_InsertOrUpdate
	@empID NVARCHAR(15),
	@pc_XangXe FLOAT = 0
AS

UPDATE dbo.tbPhuCapCoDinh
SET pc_XangXe = @pc_XangXe
WHERE employeeID = @empID

IF @@ROWCOUNT = 0
INSERT dbo.tbPhuCapCoDinh
        ( id, employeeID, pc_XangXe )
VALUES  ( NEWID(), -- id - uniqueidentifier
          @empID, -- employeeID - varchar(15)
          @pc_XangXe  -- pc_XangXe - float
          )

go





CREATE PROC p_tbPhuCapCoDinh_InsertByDep
	@depID NVARCHAR(15),
	@pc_XangXe FLOAT = 0
AS

DECLARE @depIDs TABLE(id NVARCHAR(10))
INSERT @depIDs( id )
VALUES (@depID)

INSERT @depIDs( id )
SELECT d.DepID
FROM dbo.tblRef_Department d
WHERE ISNULL(d.DepParent,'') = ISNULL(@depID,'')

INSERT @depIDs( id )
SELECT d.DepID
FROM dbo.tblRef_Department d
	INNER JOIN @depIDs dd ON d.DepParent = dd.id
WHERE dd.id != @depID

UPDATE dbo.tbPhuCapCoDinh
SET pc_XangXe = @pc_XangXe
FROM dbo.tbPhuCapCoDinh c
	INNER JOIN dbo.tblEmployee e ON c.employeeID = e.EmployeeID
	INNER JOIN @depIDs d ON e.DepID = d.id

INSERT dbo.tbPhuCapCoDinh
        ( id, employeeID, pc_XangXe )
SELECT    NEWID(), -- id - uniqueidentifier
          e.EmployeeID, -- employeeID - varchar(15)
          @pc_XangXe  -- pc_XangXe - float
FROM tblEmployee e
	LEFT JOIN dbo.tbPhuCapCoDinh c ON e.EmployeeID = c.employeeID
	INNER JOIN @depIDs d ON e.DepID = d.id
WHERE c.id IS NULL

go







