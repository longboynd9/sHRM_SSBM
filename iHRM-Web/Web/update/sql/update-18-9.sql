
/****** Object:  Table [dbo].[tbNgayNghiPhepNam]    Script Date: 09/18/2015 13:18:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbNgayNghiPhepNam](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ngay] [date] NULL,
	[tinhNam] [bit] NULL,
	[ten] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbNgayNghiPhepNam] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE PROCEDURE p_chamcong_UpdateReportMonth
	@id UNIQUEIDENTIFIER,
	@trangThai INT,
	@tgQuetDen TIME(0),
	@tgQuetVe TIME(0),
	@tgDiMuon INT,
	@tgVeSom INT
AS
BEGIN

	UPDATE dbo.tbKetQuaQuetThe
	SET trangThai = @trangThai,
		tgQuetDen = @tgQuetDen,
		tgQuetVe = @tgQuetVe,
		tgDiMuon = @tgDiMuon,
		tgVeSom = @tgVeSom
	WHERE id = @id
	
END

go


CREATE PROC [dbo].[p_tinhLuong_ResetBangLuong]
	@thang DATETIME
AS

DELETE dbo.tbBangLuongThang
WHERE thang = @thang

GO


CREATE PROC [dbo].[p_tinhLuong_GetAllKetQuaQuetThe]
	@tuNgay DATETIME,
	@denNgay DATETIME
AS

SET NOCOUNT ON

SELECT kq.*
FROM dbo.tbKetQuaQuetThe kq
WHERE ngay >= @tuNgay
	AND ngay < @denNgay




go


ALTER PROC [dbo].[p_chamcong_GetReportMonth]
	@tuNgay DATETIME = NULL,
	@denNgay DATETIME = NULL,
	@empID NVARCHAR(50) = NULL,
	@depID NVARCHAR(50) = NULL	
AS

SET NOCOUNT ON

SELECT kq.id, kq.EmployeeID, nv.EmployeeName, nv.AppliedDate, kq.ngay, kq.trangThai, kq.tgDiMuon, kq.tgQuetDen, kq.tgQuetVe, kq.tgVeSom, kq.tgTinhTangCa
FROM dbo.tbKetQuaQuetThe kq
	INNER JOIN dbo.tblEmployee nv ON kq.EmployeeID = nv.EmployeeID
WHERE (@tuNgay IS NULL OR kq.ngay >= @tuNgay)
	AND (@denNgay IS NULL OR kq.ngay < @denNgay)
	AND (@empID IS NULL OR kq.EmployeeID = @empID)
	AND (@depID IS NULL OR nv.DepID = @depID)


go
ALTER PROC [dbo].[p_tinhLuong_GetAllKetQuaQuetThe]
	@tuNgay DATETIME,
	@denNgay DATETIME
AS

SET NOCOUNT ON

SELECT kq.*,
	e.EmployeeName, e.BasicSalary
	
FROM dbo.tbKetQuaQuetThe kq
	INNER JOIN dbo.tblEmployee e ON kq.EmployeeID = e.EmployeeID
WHERE ngay >= @tuNgay
	AND ngay < @denNgay



go


CREATE PROC p_tinhLuong_GetThamSoTinhLuong
	@thang DATE,
	@empID NVARCHAR(20) = NULL
AS
SET NOCOUNT ON

SELECT *
FROM dbo.tbThamSoTinhLuong
WHERE thang = @thang
	AND (ISNULL(@empID,'')='' OR employeeID = @empID)