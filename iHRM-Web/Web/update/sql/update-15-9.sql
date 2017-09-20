
CREATE PROC [dbo].[p_chamcong_GetReportQuetTheByDate]
	@Ngay DATETIME = NULL,
	@DepartmentID NVARCHAR(50) = NULL
AS

SET NOCOUNT ON

SELECT kq.id, kq.EmployeeID,nv.EmployeeCode, nv.EmployeeName,nv.DepName,nv.SexID, nv.AppliedDate, kq.ngay, kq.trangThai, kq.tgDiMuon, kq.tgQuetDen, kq.tgQuetVe, kq.tgVeSom
FROM dbo.tbKetQuaQuetThe kq
	INNER JOIN dbo.tblEmployee nv ON kq.EmployeeID = nv.EmployeeID
WHERE (@Ngay IS NULL OR DATEDIFF(day,kq.ngay,@Ngay)=0)
	AND (@DepartmentID IS NULL OR nv.DepID = @DepartmentID)order by nv.EmployeeName ASC
go










CREATE PROC [dbo].[p_chamcong_CaNhan_DangKyCaLam_tapThe]
	@maTapThe NVARCHAR(15),
	@ngay DATETIME,
	@idCaLam UNIQUEIDENTIFIER,
	@dkLamThem INT = NULL,
	@hsLuong INT = NULL
AS

UPDATE dbo.tbKetQuaQuetThe
SET idCaLam = @idCaLam,
	dkLamThem = @dkLamThem,
	heSoLuong = @hsLuong
FROM tbKetQuaQuetThe k
	INNER JOIN dbo.tblEmployee e ON k.EmployeeID = e.EmployeeID AND k.ngay = @ngay
WHERE e.DepID = @maTapThe

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
WHERE e.DepID = @maTapThe AND ISNULL(e.IsNotOT,0)=0
go
















ALTER PROC [dbo].[p_chamcong_GetReportMonth]
	@tuNgay DATETIME = NULL,
	@denNgay DATETIME = NULL,
	@empID NVARCHAR(50) = NULL,
	@depID NVARCHAR(50) = NULL	
AS

SET NOCOUNT ON

SELECT kq.id, kq.EmployeeID, nv.EmployeeName, nv.AppliedDate, kq.ngay, kq.trangThai, kq.tgDiMuon, kq.tgQuetDen, kq.tgQuetVe, kq.tgVeSom
FROM dbo.tbKetQuaQuetThe kq
	INNER JOIN dbo.tblEmployee nv ON kq.EmployeeID = nv.EmployeeID
WHERE (@tuNgay IS NULL OR kq.ngay >= @tuNgay)
	AND (@denNgay IS NULL OR kq.ngay < @denNgay)
	AND (@empID IS NULL OR kq.EmployeeID = @empID)
	AND (@depID IS NULL OR nv.DepID = @depID)
go