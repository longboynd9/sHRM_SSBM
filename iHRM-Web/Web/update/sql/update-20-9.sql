

alter PROC [dbo].[p_chamcong_GetReportQuetTheByMonth]
	@tuNgay DATETIME = NULL,
	@todate datetime =NULL,
	@depID NVARCHAR(50) = NULL,
	@Page INT = 1,
	@PageSize INT = 100,
	@RecordCount INT OUTPUT
AS

SET NOCOUNT ON
SELECT *
FROM(	SELECT ROW_NUMBER() OVER (ORDER BY EmployeeCode) RowNum,kq.id, kq.EmployeeID,nv.EmployeeCode, nv.EmployeeName,nv.DepName,nv.SexID, nv.AppliedDate, kq.ngay, kq.trangThai, kq.tgDiMuon, kq.tgQuetDen, kq.tgQuetVe, kq.tgVeSom,kq.tgTinhTangCa
	FROM dbo.tbKetQuaQuetThe kq
		INNER JOIN dbo.tblEmployee nv ON kq.EmployeeID = nv.EmployeeID
	WHERE (@tuNgay IS NULL OR kq.ngay >= @tuNgay)
		   AND (@todate IS NULL OR kq.ngay <= @todate)
		   AND (@depID IS NULL OR nv.DepID = @depID) 
	) as t
	WHERE t.RowNum > (@Page-1)*@PageSize AND t.RowNum <= @Page*@PageSize order by t.EmployeeName ASC, t.ngay ASC
SET @RecordCount = (
	SELECT COUNT(*)
	FROM dbo.tbKetQuaQuetThe kq		INNER JOIN dbo.tblEmployee nv ON kq.EmployeeID = nv.EmployeeID	WHERE (@tuNgay IS NULL OR kq.ngay >= @tuNgay)
	AND (@todate IS NULL OR kq.ngay <= @todate)
	AND (@depID IS NULL OR nv.DepID = @depID)
)
 go
alter PROC [dbo].[p_BaoCao_GetReportMonth]
	@tuNgay DATETIME = NULL,
	@denNgay DATETIME = NULL,
	@empID NVARCHAR(50) = NULL,
	@depID NVARCHAR(50) = NULL	
AS

SET NOCOUNT ON

SELECT  kq.id,kq.kqNgayCong, kq.EmployeeID,kq.tgTinhTangCa,nv.PosName,nv.AppliedDate, nv.DepName, nv.EmployeeName, nv.AppliedDate, kq.ngay, kq.trangThai, kq.tgDiMuon, kq.tgQuetDen, kq.tgQuetVe, kq.tgVeSom
FROM dbo.tbKetQuaQuetThe kq
	INNER JOIN dbo.tblEmployee nv ON kq.EmployeeID = nv.EmployeeID
WHERE (@tuNgay IS NULL OR kq.ngay >= @tuNgay)
	AND (@denNgay IS NULL OR kq.ngay <= @denNgay)
	AND (@empID IS NULL OR kq.EmployeeID = @empID)
	AND (@depID IS NULL OR nv.DepID = @depID)
	 order by nv.DepName
	