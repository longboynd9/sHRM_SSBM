
ALTER PROC [dbo].[p_duLieuQuetThe_GetAllKetQuaQuetThe_CoThe]
	@tuNgay DATETIME,
	@denNgay DATETIME
AS

SET NOCOUNT ON

UPDATE dbo.tbKetQuaQuetThe
SET trangThai = 0
FROM dbo.tbKetQuaQuetThe k
	INNER JOIN (
		SELECT DISTINCT maThe
		FROM dbo.tbDuLieuQuetThe
	) d ON k.CardID = d.maThe
WHERE k.ngay >= @tuNgay
	AND k.ngay < @denNgay



SELECT  k.id ,
        k.EmployeeID,
        k.CardID ,
        k.ngay ,
        k.idCaLam ,
        k.trangThai ,
        k.tgQuetDen ,
        k.tgQuetVe ,
        k.tgDiMuon ,
        k.tgVeSom
FROM dbo.tbKetQuaQuetThe k
	INNER JOIN (
		SELECT DISTINCT maThe
		FROM dbo.tbDuLieuQuetThe
	) d ON k.CardID = d.maThe
WHERE k.ngay >= @tuNgay
	AND k.ngay < @denNgay
