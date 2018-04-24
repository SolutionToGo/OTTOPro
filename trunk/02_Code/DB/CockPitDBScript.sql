CREATE PROCEDURE P_Ins_InsertOTTOProData
@dtData dtEsitmates READONLY,
@ProjectNumber NVARCHAR(50),
@ProjectDescription NVARCHAR(MAX),
@ProjectStartDate DATETIME,
@ProjectEndDate DATETIME,
@UserName NVARCHAR(50)
AS
BEGIN

BEGIN TRY
	BEGIN TRAN
		IF NOT EXISTS(SELECT 1 FROM tblProjects WHERE project_number = @ProjectNumber)
			BEGIN
				INSERT INTO tblProjects
				(
				project_number,
				project_description,
				project_start_date,
				project_end_date,
				project_type,
				factor_calculation_type,
				create_date,
				created_by
				)
				VALUES
				(
				@ProjectNumber,
				@ProjectDescription,
				@ProjectStartDate,
				@ProjectEndDate,
				'mit Werkvertrag',
				'Mit TB',
				GETDATE(),
				@UserName
				)
				INSERT INTO tblProjectEstimate(
				project_number,
				account_id,
				base_estimate,
				create_date,
				created_by
				)
				SELECT
				@ProjectNumber,
				AccontNumber,
				Value,
				GETDATE(),
				@UserName
				FROM @dtData
			END
		ELSE
			BEGIN

				UPDATE tblProjects SET
				project_description = @ProjectDescription,
				project_start_date = @ProjectStartDate,
				project_end_date = @ProjectEndDate,
				modified_by = @UserName,
				modify_date = GETDATE()
				WHERE project_number = @ProjectNumber

				MERGE tblProjectEstimate AS Trg
				USING (SELECT AccontNumber,Value FROM @dtData) AS Src	
				ON Trg.account_id = Src.AccontNumber AND Trg.project_number = @ProjectNumber
				WHEN MATCHED
				THEN UPDATE SET 
				Trg.base_estimate = Src.Value,
				Trg.modified_by = @UserName,
				Trg.modify_date = GETDATE()
				WHEN NOT MATCHED THEN
				INSERT(
				project_number,
				account_id,
				base_estimate,
				create_date,
				created_by
				)
				VALUES(
				@ProjectNumber,
				Src.AccontNumber,
				Src.Value,
				GETDATE(),
				@UserName
				);
			END
	COMMIT TRAN
END TRY
BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ErrorMessage	
		IF(@@TRANCOUNT > 0)
			ROLLBACK TRAN
END CATCH

END