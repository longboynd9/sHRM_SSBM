
ALTER TABLE dbo.tbBangLuongThang
ADD approved INT
GO


CREATE PROC p_tinhLuong_UpdateApprovedStt
	@id UNIQUEIDENTIFIER,
	@approved INT = NULL
AS

UPDATE dbo.tbBangLuongThang
SET approved = @approved
WHERE id = @id
GO