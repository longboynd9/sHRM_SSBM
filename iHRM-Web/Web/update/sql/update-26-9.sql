go
ALTER PROC [dbo].[p_chamcong_GetReportQuetTheByDate]
	@Ngay DATETIME = NULL,
	@DepartmentID NVARCHAR(50) = NULL
AS

SET NOCOUNT ON

SELECT kq.id, kq.EmployeeID,nv.EmployeeCode,kq.tgQuetDen,kq.tgQuetVe,ca.ten, nv.EmployeeName,nv.DepName,nv.PosName,nv.IDCard, nv.SexID, nv.AppliedDate, kq.ngay, kq.trangThai, kq.tgDiMuon, kq.tgQuetDen, kq.tgQuetVe, kq.tgVeSom
FROM dbo.tbKetQuaQuetThe kq
	INNER JOIN dbo.tblEmployee nv ON kq.EmployeeID = nv.EmployeeID inner join dbo.tbCaLamViec ca on kq.idCaLam= ca.id
WHERE (@Ngay IS NULL OR DATEDIFF(day,kq.ngay,@Ngay)=0)
	AND (@DepartmentID IS NULL OR nv.DepID = @DepartmentID)order by nv.EmployeeName ASC