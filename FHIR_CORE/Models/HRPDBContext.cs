using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FHIR_CORE.Models
{
    public partial class HRPDBContext : DbContext
    {
        public HRPDBContext()
        {
        }

        public HRPDBContext(DbContextOptions<HRPDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthGroup> AuthGroups { get; set; } = null!;
        public virtual DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; } = null!;
        public virtual DbSet<AuthPermission> AuthPermissions { get; set; } = null!;
        public virtual DbSet<AuthUser> AuthUsers { get; set; } = null!;
        public virtual DbSet<AuthUserGroup> AuthUserGroups { get; set; } = null!;
        public virtual DbSet<AuthUserUserPermission> AuthUserUserPermissions { get; set; } = null!;
        public virtual DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; } = null!;
        public virtual DbSet<DjangoContentType> DjangoContentTypes { get; set; } = null!;
        public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; } = null!;
        public virtual DbSet<DjangoSession> DjangoSessions { get; set; } = null!;
        public virtual DbSet<HrpConsentartefact> HrpConsentartefacts { get; set; } = null!;
        public virtual DbSet<HrpConsentrequest> HrpConsentrequests { get; set; } = null!;
        public virtual DbSet<HrpDiagnosticreportattachment> HrpDiagnosticreportattachments { get; set; } = null!;
        public virtual DbSet<HrpHealthfacilityregistry> HrpHealthfacilityregistries { get; set; } = null!;
        public virtual DbSet<HrpHidocument> HrpHidocuments { get; set; } = null!;
        public virtual DbSet<HrpHipconsentrequest> HrpHipconsentrequests { get; set; } = null!;
        public virtual DbSet<HrpHiphealthinforequest> HrpHiphealthinforequests { get; set; } = null!;
        public virtual DbSet<HrpHipinitrequest> HrpHipinitrequests { get; set; } = null!;
        public virtual DbSet<HrpHiprequest> HrpHiprequests { get; set; } = null!;
        public virtual DbSet<HrpImagingtestmaster> HrpImagingtestmasters { get; set; } = null!;
        public virtual DbSet<HrpLabtestmaster> HrpLabtestmasters { get; set; } = null!;
        public virtual DbSet<HrpLocationsmaster> HrpLocationsmasters { get; set; } = null!;
        public virtual DbSet<HrpLocationsmasterlgd> HrpLocationsmasterlgds { get; set; } = null!;
        public virtual DbSet<HrpPatient> HrpPatients { get; set; } = null!;
        public virtual DbSet<HrpPatientclinicalnotesdtl> HrpPatientclinicalnotesdtls { get; set; } = null!;
        public virtual DbSet<HrpPatientdiagnosticreportdtl> HrpPatientdiagnosticreportdtls { get; set; } = null!;
        public virtual DbSet<HrpPatientdischargenotesdtl> HrpPatientdischargenotesdtls { get; set; } = null!;
        public virtual DbSet<HrpPatientprescriptiondtl> HrpPatientprescriptiondtls { get; set; } = null!;
        public virtual DbSet<HrpPatientvisitdtl> HrpPatientvisitdtls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthGroup>(entity =>
            {
                entity.ToTable("auth_group");

                entity.HasIndex(e => e.Name, "auth_group_name_a6ea08ec_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.HasIndex(e => e.Name, "auth_group_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AuthGroupPermission>(entity =>
            {
                entity.ToTable("auth_group_permissions");

                entity.HasIndex(e => e.GroupId, "auth_group_permissions_group_id_b120cbf9");

                entity.HasIndex(e => new { e.GroupId, e.PermissionId }, "auth_group_permissions_group_id_permission_id_0cd325b0_uniq")
                    .IsUnique();

                entity.HasIndex(e => e.PermissionId, "auth_group_permissions_permission_id_84c5c92e");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AuthGroupPermissions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_group_permissions_group_id_b120cbf9_fk_auth_group_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AuthGroupPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_group_permissio_permission_id_84c5c92e_fk_auth_perm");
            });

            modelBuilder.Entity<AuthPermission>(entity =>
            {
                entity.ToTable("auth_permission");

                entity.HasIndex(e => e.ContentTypeId, "auth_permission_content_type_id_2f476e4b");

                entity.HasIndex(e => new { e.ContentTypeId, e.Codename }, "auth_permission_content_type_id_codename_01ab375a_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codename)
                    .HasMaxLength(100)
                    .HasColumnName("codename");

                entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.AuthPermissions)
                    .HasForeignKey(d => d.ContentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_permission_content_type_id_2f476e4b_fk_django_co");
            });

            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.ToTable("auth_user");

                entity.HasIndex(e => e.Username, "auth_user_username_6821ab7c_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.HasIndex(e => e.Username, "auth_user_username_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateJoined).HasColumnName("date_joined");

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(150)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsStaff).HasColumnName("is_staff");

                entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");

                entity.Property(e => e.LastLogin).HasColumnName("last_login");

                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<AuthUserGroup>(entity =>
            {
                entity.ToTable("auth_user_groups");

                entity.HasIndex(e => e.GroupId, "auth_user_groups_group_id_97559544");

                entity.HasIndex(e => e.UserId, "auth_user_groups_user_id_6a12ed8b");

                entity.HasIndex(e => new { e.UserId, e.GroupId }, "auth_user_groups_user_id_group_id_94350c0c_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AuthUserGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_user_groups_group_id_97559544_fk_auth_group_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuthUserGroups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_user_groups_user_id_6a12ed8b_fk_auth_user_id");
            });

            modelBuilder.Entity<AuthUserUserPermission>(entity =>
            {
                entity.ToTable("auth_user_user_permissions");

                entity.HasIndex(e => e.PermissionId, "auth_user_user_permissions_permission_id_1fbb5f2c");

                entity.HasIndex(e => e.UserId, "auth_user_user_permissions_user_id_a95ead1b");

                entity.HasIndex(e => new { e.UserId, e.PermissionId }, "auth_user_user_permissions_user_id_permission_id_14a6b632_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AuthUserUserPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_user_user_permi_permission_id_1fbb5f2c_fk_auth_perm");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuthUserUserPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_user_user_permissions_user_id_a95ead1b_fk_auth_user_id");
            });

            modelBuilder.Entity<DjangoAdminLog>(entity =>
            {
                entity.ToTable("django_admin_log");

                entity.HasIndex(e => e.ContentTypeId, "django_admin_log_content_type_id_c4bce8eb");

                entity.HasIndex(e => e.UserId, "django_admin_log_user_id_c564eba6");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionFlag).HasColumnName("action_flag");

                entity.Property(e => e.ActionTime).HasColumnName("action_time");

                entity.Property(e => e.ChangeMessage).HasColumnName("change_message");

                entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.ObjectRepr)
                    .HasMaxLength(200)
                    .HasColumnName("object_repr");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.DjangoAdminLogs)
                    .HasForeignKey(d => d.ContentTypeId)
                    .HasConstraintName("django_admin_log_content_type_id_c4bce8eb_fk_django_co");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DjangoAdminLogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("django_admin_log_user_id_c564eba6_fk_auth_user_id");
            });

            modelBuilder.Entity<DjangoContentType>(entity =>
            {
                entity.ToTable("django_content_type");

                entity.HasIndex(e => new { e.AppLabel, e.Model }, "django_content_type_app_label_model_76bd3d3b_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppLabel)
                    .HasMaxLength(100)
                    .HasColumnName("app_label");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .HasColumnName("model");
            });

            modelBuilder.Entity<DjangoMigration>(entity =>
            {
                entity.ToTable("django_migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.App)
                    .HasMaxLength(255)
                    .HasColumnName("app");

                entity.Property(e => e.Applied).HasColumnName("applied");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<DjangoSession>(entity =>
            {
                entity.HasKey(e => e.SessionKey)
                    .HasName("django_session_pkey");

                entity.ToTable("django_session");

                entity.HasIndex(e => e.ExpireDate, "django_session_expire_date_a5c62663");

                entity.HasIndex(e => e.SessionKey, "django_session_session_key_c0390e0f_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.SessionKey)
                    .HasMaxLength(40)
                    .HasColumnName("session_key");

                entity.Property(e => e.ExpireDate).HasColumnName("expire_date");

                entity.Property(e => e.SessionData).HasColumnName("session_data");
            });

            modelBuilder.Entity<HrpConsentartefact>(entity =>
            {
                entity.HasKey(e => e.ConsentArtefactId)
                    .HasName("HRP_consentartefact_pkey");

                entity.ToTable("HRP_consentartefact");

                entity.HasIndex(e => e.ConsentArtefactId, "HRP_consentartefact_consent_artefact_id_cb29ee08_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.ConsentArtefactId)
                    .HasMaxLength(255)
                    .HasColumnName("consent_artefact_id");

                entity.Property(e => e.ConsentId)
                    .HasMaxLength(255)
                    .HasColumnName("consent_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<HrpConsentrequest>(entity =>
            {
                entity.HasKey(e => e.ConsentRequestId)
                    .HasName("HRP_consentrequest_pkey");

                entity.ToTable("HRP_consentrequest");

                entity.HasIndex(e => e.ConsentRequestId, "HRP_consentrequest_consent_request_id_021ad4b5_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.ConsentRequestId)
                    .HasMaxLength(255)
                    .HasColumnName("consent_request_id");

                entity.Property(e => e.ConsentCreatedDt)
                    .HasMaxLength(255)
                    .HasColumnName("consent_created_dt");

                entity.Property(e => e.ConsentExpiryDt)
                    .HasMaxLength(255)
                    .HasColumnName("consent_expiry_dt");

                entity.Property(e => e.ConsentGrantDt)
                    .HasMaxLength(255)
                    .HasColumnName("consent_grant_dt");

                entity.Property(e => e.ConsentId)
                    .HasMaxLength(255)
                    .HasColumnName("consent_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DischargeYn)
                    .HasMaxLength(255)
                    .HasColumnName("discharge_yn");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(255)
                    .HasColumnName("doctor_id");

                entity.Property(e => e.FacilityId)
                    .HasMaxLength(255)
                    .HasColumnName("facility_id");

                entity.Property(e => e.HealthExpiryFromDt)
                    .HasMaxLength(255)
                    .HasColumnName("health_expiry_from_dt");

                entity.Property(e => e.HealthExpiryToDt)
                    .HasMaxLength(255)
                    .HasColumnName("health_expiry_to_dt");

                entity.Property(e => e.HealthInfoFromDt)
                    .HasMaxLength(255)
                    .HasColumnName("health_info_from_dt");

                entity.Property(e => e.HealthInfoToDt)
                    .HasMaxLength(255)
                    .HasColumnName("health_info_to_dt");

                entity.Property(e => e.ImageYn)
                    .HasMaxLength(255)
                    .HasColumnName("image_yn");

                entity.Property(e => e.LabYn)
                    .HasMaxLength(255)
                    .HasColumnName("lab_yn");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.OpYn)
                    .HasMaxLength(255)
                    .HasColumnName("op_yn");

                entity.Property(e => e.PrescriptionYn)
                    .HasMaxLength(255)
                    .HasColumnName("prescription_yn");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(255)
                    .HasColumnName("purpose");

                entity.Property(e => e.SwasthyaId)
                    .HasMaxLength(255)
                    .HasColumnName("swasthya_id");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.VisitId)
                    .HasMaxLength(255)
                    .HasColumnName("visit_id");
            });

            modelBuilder.Entity<HrpDiagnosticreportattachment>(entity =>
            {
                entity.ToTable("HRP_diagnosticreportattachment");

                entity.HasIndex(e => e.ReportId, "HRP_diagnosticreportattachment_report_id_ad09fc8a");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActiveYn)
                    .HasMaxLength(255)
                    .HasColumnName("active_yn");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.ReportFilePath)
                    .HasMaxLength(255)
                    .HasColumnName("report_file_path");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.HrpDiagnosticreportattachments)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("HRP_diagnosticreport_report_id_ad09fc8a_fk_HRP_patie");
            });

            modelBuilder.Entity<HrpHealthfacilityregistry>(entity =>
            {
                entity.ToTable("HRP_healthfacilityregistry");

                entity.HasIndex(e => e.Id, "HRP_healthfacilityregistry_id_dd3f877a_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Alias)
                    .HasColumnType("jsonb")
                    .HasColumnName("alias");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<HrpHidocument>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("HRP_hidocument_pkey");

                entity.ToTable("HRP_hidocument");

                entity.Property(e => e.DocId).HasColumnName("doc_id");

                entity.Property(e => e.CareContextDisplay)
                    .HasMaxLength(256)
                    .HasColumnName("care_context_display");

                entity.Property(e => e.ConsentTxnNum)
                    .HasMaxLength(256)
                    .HasColumnName("consent_txn_num");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.FhirObject).HasColumnName("fhir_object");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<HrpHipconsentrequest>(entity =>
            {
                entity.ToTable("HRP_hipconsentrequest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConsentCreatedDt)
                    .HasMaxLength(255)
                    .HasColumnName("consent_created_dt");

                entity.Property(e => e.ConsentExpiryDt)
                    .HasMaxLength(255)
                    .HasColumnName("consent_expiry_dt");

                entity.Property(e => e.ConsentGrantDt)
                    .HasMaxLength(255)
                    .HasColumnName("consent_grant_dt");

                entity.Property(e => e.ConsentId)
                    .HasMaxLength(100)
                    .HasColumnName("consent_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DischargeYn)
                    .HasMaxLength(3)
                    .HasColumnName("discharge_yn");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(100)
                    .HasColumnName("doctor_id");

                entity.Property(e => e.FacilityId)
                    .HasMaxLength(100)
                    .HasColumnName("facility_id");

                entity.Property(e => e.HealthExpiryFromDt)
                    .HasMaxLength(255)
                    .HasColumnName("health_expiry_from_dt");

                entity.Property(e => e.HealthExpiryToDt)
                    .HasMaxLength(255)
                    .HasColumnName("health_expiry_to_dt");

                entity.Property(e => e.HealthInfoFromDt)
                    .HasMaxLength(255)
                    .HasColumnName("health_info_from_dt");

                entity.Property(e => e.HealthInfoToDt)
                    .HasMaxLength(255)
                    .HasColumnName("health_info_to_dt");

                entity.Property(e => e.ImageYn)
                    .HasMaxLength(3)
                    .HasColumnName("image_yn");

                entity.Property(e => e.LabYn)
                    .HasMaxLength(3)
                    .HasColumnName("lab_yn");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.OpYn)
                    .HasMaxLength(3)
                    .HasColumnName("op_yn");

                entity.Property(e => e.PrescriptionYn)
                    .HasMaxLength(3)
                    .HasColumnName("prescription_yn");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(100)
                    .HasColumnName("purpose");

                entity.Property(e => e.SwasthyaId)
                    .HasMaxLength(100)
                    .HasColumnName("swasthya_id");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.VisitId)
                    .HasMaxLength(10000)
                    .HasColumnName("visit_id");
            });

            modelBuilder.Entity<HrpHiphealthinforequest>(entity =>
            {
                entity.HasKey(e => e.ConsentId)
                    .HasName("HRP_hiphealthinforequest_pkey");

                entity.ToTable("HRP_hiphealthinforequest");

                entity.HasIndex(e => e.ConsentId, "HRP_hiphealthinforequest_consent_id_301f60c2_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.ConsentId)
                    .HasMaxLength(255)
                    .HasColumnName("consent_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CryptoAlg)
                    .HasMaxLength(255)
                    .HasColumnName("crypto_alg");

                entity.Property(e => e.Curve)
                    .HasMaxLength(255)
                    .HasColumnName("curve");

                entity.Property(e => e.DataPushUrl)
                    .HasMaxLength(255)
                    .HasColumnName("data_push_url");

                entity.Property(e => e.DateRangeFrom)
                    .HasMaxLength(255)
                    .HasColumnName("date_range_from");

                entity.Property(e => e.DateRangeTo)
                    .HasMaxLength(255)
                    .HasColumnName("date_range_to");

                entity.Property(e => e.Nonce)
                    .HasMaxLength(100000)
                    .HasColumnName("nonce");

                entity.Property(e => e.PublicKeyExpiry)
                    .HasMaxLength(255)
                    .HasColumnName("public_key_expiry");

                entity.Property(e => e.PublicKeyParam)
                    .HasMaxLength(100000)
                    .HasColumnName("public_key_param");

                entity.Property(e => e.PublicKeyValue)
                    .HasMaxLength(100000)
                    .HasColumnName("public_key_value");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<HrpHipinitrequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("HRP_hipinitrequest_pkey");

                entity.ToTable("HRP_hipinitrequest");

                entity.HasIndex(e => e.RequestId, "HRP_hipinitrequest_request_id_c9283e83_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.RequestId)
                    .HasMaxLength(255)
                    .HasColumnName("request_id");

                entity.Property(e => e.AuthType)
                    .HasMaxLength(255)
                    .HasColumnName("auth_type");

                entity.Property(e => e.Authorisation)
                    .HasMaxLength(255)
                    .HasColumnName("authorisation");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Dob)
                    .HasMaxLength(255)
                    .HasColumnName("dob");

                entity.Property(e => e.Gender)
                    .HasMaxLength(255)
                    .HasColumnName("gender");

                entity.Property(e => e.HealhId)
                    .HasMaxLength(255)
                    .HasColumnName("healh_id");

                entity.Property(e => e.HospRegId)
                    .HasMaxLength(255)
                    .HasColumnName("hosp_reg_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.ReferenceConfirm)
                    .HasMaxLength(255)
                    .HasColumnName("reference_confirm");

                entity.Property(e => e.ReferenceInit)
                    .HasMaxLength(255)
                    .HasColumnName("reference_init");

                entity.Property(e => e.RequestTimestamp)
                    .HasMaxLength(255)
                    .HasColumnName("request_timestamp");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(255)
                    .HasColumnName("transaction_id");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<HrpHiprequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("HRP_hiprequest_pkey");

                entity.ToTable("HRP_hiprequest");

                entity.HasIndex(e => e.RequestId, "HRP_hiprequest_request_id_d6e00f0f_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.RequestId)
                    .HasMaxLength(255)
                    .HasColumnName("request_id");

                entity.Property(e => e.Authoriszation)
                    .HasMaxLength(255000)
                    .HasColumnName("authoriszation");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.HospRegId)
                    .HasMaxLength(255)
                    .HasColumnName("hosp_reg_id");

                entity.Property(e => e.RequestBody).HasColumnName("request_body");

                entity.Property(e => e.RequestServed)
                    .HasMaxLength(255)
                    .HasColumnName("request_served");

                entity.Property(e => e.RequestTimestamp)
                    .HasMaxLength(255)
                    .HasColumnName("request_timestamp");

                entity.Property(e => e.RequestType)
                    .HasMaxLength(255)
                    .HasColumnName("request_type");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(255)
                    .HasColumnName("transaction_id");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<HrpImagingtestmaster>(entity =>
            {
                entity.ToTable("HRP_imagingtestmaster");

                entity.HasIndex(e => e.Id, "HRP_imagingtestmaster_id_62c86160_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.ParentId)
                    .HasMaxLength(100)
                    .HasColumnName("parent_id");

                entity.Property(e => e.TestDescription)
                    .HasMaxLength(500)
                    .HasColumnName("test_description");

                entity.Property(e => e.TestId)
                    .HasMaxLength(200)
                    .HasColumnName("test_id");
            });

            modelBuilder.Entity<HrpLabtestmaster>(entity =>
            {
                entity.ToTable("HRP_labtestmaster");

                entity.HasIndex(e => e.Id, "HRP_labtestmaster_id_56f873e4_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.LoincId)
                    .HasMaxLength(100)
                    .HasColumnName("loinc_id");

                entity.Property(e => e.ParentId)
                    .HasMaxLength(100)
                    .HasColumnName("parent_id");

                entity.Property(e => e.TestId)
                    .HasMaxLength(200)
                    .HasColumnName("test_id");

                entity.Property(e => e.TestOrderName)
                    .HasMaxLength(500)
                    .HasColumnName("test_order_name");
            });

            modelBuilder.Entity<HrpLocationsmaster>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("HRP_locationsmaster_pkey");

                entity.ToTable("HRP_locationsmaster");

                entity.Property(e => e.Sno).HasColumnName("sno");

                entity.Property(e => e.ActiveYn)
                    .HasMaxLength(10)
                    .HasColumnName("active_yn");

                entity.Property(e => e.BlockCode)
                    .HasMaxLength(10)
                    .HasColumnName("block_code");

                entity.Property(e => e.BlockName)
                    .HasMaxLength(1000)
                    .HasColumnName("block_name");

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(10)
                    .HasColumnName("district_code");

                entity.Property(e => e.DistrictName)
                    .HasMaxLength(1000)
                    .HasColumnName("district_name");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(10)
                    .HasColumnName("state_code");

                entity.Property(e => e.StateName)
                    .HasMaxLength(1000)
                    .HasColumnName("state_name");

                entity.Property(e => e.SubDistrictCode)
                    .HasMaxLength(10)
                    .HasColumnName("sub_district_code");

                entity.Property(e => e.SubDistrictName)
                    .HasMaxLength(1000)
                    .HasColumnName("sub_district_name");

                entity.Property(e => e.VillageCode)
                    .HasMaxLength(10)
                    .HasColumnName("village_code");

                entity.Property(e => e.VillageName)
                    .HasMaxLength(1000)
                    .HasColumnName("village_name");
            });

            modelBuilder.Entity<HrpLocationsmasterlgd>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("HRP_locationsmasterlgd_pkey");

                entity.ToTable("HRP_locationsmasterlgd");

                entity.HasIndex(e => e.Sno, "HRP_locationsmasterlgd_sno_29cf9443_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.Sno)
                    .HasMaxLength(255)
                    .HasColumnName("sno");

                entity.Property(e => e.ActiveYn)
                    .HasMaxLength(255)
                    .HasColumnName("active_yn");

                entity.Property(e => e.BlockCode)
                    .HasMaxLength(255)
                    .HasColumnName("block_code");

                entity.Property(e => e.BlockName)
                    .HasMaxLength(255)
                    .HasColumnName("block_name");

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(255)
                    .HasColumnName("district_code");

                entity.Property(e => e.DistrictName)
                    .HasMaxLength(255)
                    .HasColumnName("district_name");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(255)
                    .HasColumnName("state_code");

                entity.Property(e => e.StateName)
                    .HasMaxLength(255)
                    .HasColumnName("state_name");

                entity.Property(e => e.SubDistrictCode)
                    .HasMaxLength(255)
                    .HasColumnName("sub_district_code");

                entity.Property(e => e.SubDistrictName)
                    .HasMaxLength(255)
                    .HasColumnName("sub_district_name");

                entity.Property(e => e.VillageCode)
                    .HasMaxLength(255)
                    .HasColumnName("village_code");

                entity.Property(e => e.VillageName)
                    .HasMaxLength(255)
                    .HasColumnName("village_name");
            });

            modelBuilder.Entity<HrpPatient>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("HRP_patient_pkey");

                entity.ToTable("HRP_patient");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.Age)
                    .HasMaxLength(30)
                    .HasColumnName("age");

                entity.Property(e => e.BirthDt).HasColumnName("birth_dt");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(100)
                    .HasColumnName("contact_number");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DistLgdCd)
                    .HasMaxLength(10)
                    .HasColumnName("dist_lgd_cd");

                entity.Property(e => e.FhirObject).HasColumnName("fhir_object");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.HipCode)
                    .HasMaxLength(100)
                    .HasColumnName("hipCode");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("last_name");

                entity.Property(e => e.LastVisitDt).HasColumnName("last_visit_dt");

                entity.Property(e => e.LastVisitType)
                    .HasMaxLength(10)
                    .HasColumnName("last_visit_type");

                entity.Property(e => e.LinkYn)
                    .HasMaxLength(255)
                    .HasColumnName("link_yn");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .HasColumnName("middle_name");

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .HasColumnName("pincode");

                entity.Property(e => e.RequestId)
                    .HasMaxLength(100)
                    .HasColumnName("requestId");

                entity.Property(e => e.StateLgdCd)
                    .HasMaxLength(10)
                    .HasColumnName("state_lgd_cd");

                entity.Property(e => e.SwasthyaId)
                    .HasMaxLength(100)
                    .HasColumnName("swasthya_id");

                entity.Property(e => e.TownLgdCd)
                    .HasMaxLength(100)
                    .HasColumnName("town_lgd_cd");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.VillageLgdCd)
                    .HasMaxLength(100)
                    .HasColumnName("village_lgd_cd");
            });

            modelBuilder.Entity<HrpPatientclinicalnotesdtl>(entity =>
            {
                entity.ToTable("HRP_patientclinicalnotesdtls");

                entity.HasIndex(e => e.VisitId, "HRP_patientclinicalnotesdtls_visit_id_ec6f0633");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Allergy)
                    .HasMaxLength(255)
                    .HasColumnName("allergy");

                entity.Property(e => e.AttachPath)
                    .HasMaxLength(255)
                    .HasColumnName("attach_path");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Diagnosis)
                    .HasMaxLength(255)
                    .HasColumnName("diagnosis");

                entity.Property(e => e.DocumentBy)
                    .HasMaxLength(100)
                    .HasColumnName("document_by");

                entity.Property(e => e.DocumentCategory)
                    .HasMaxLength(100)
                    .HasColumnName("document_category");

                entity.Property(e => e.DocumentCreatedAt)
                    .HasMaxLength(100)
                    .HasColumnName("document_created_at");

                entity.Property(e => e.DocumentCreatedDt).HasColumnName("document_created_dt");

                entity.Property(e => e.DocumentSource)
                    .HasMaxLength(100)
                    .HasColumnName("document_source");

                entity.Property(e => e.DocumentStatus)
                    .HasMaxLength(100)
                    .HasColumnName("document_status");

                entity.Property(e => e.FollowUpDt).HasColumnName("follow_up_dt");

                entity.Property(e => e.History)
                    .HasMaxLength(255)
                    .HasColumnName("history");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.Prescription)
                    .HasMaxLength(255)
                    .HasColumnName("prescription");

                entity.Property(e => e.ReportType)
                    .HasMaxLength(255)
                    .HasColumnName("report_type");

                entity.Property(e => e.Symptoms)
                    .HasMaxLength(255)
                    .HasColumnName("symptoms");

                entity.Property(e => e.TreatmentPlan)
                    .HasMaxLength(255)
                    .HasColumnName("treatment_plan");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.Property(e => e.Vitals)
                    .HasMaxLength(255)
                    .HasColumnName("vitals");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.HrpPatientclinicalnotesdtls)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("HRP_patientclinicaln_visit_id_ec6f0633_fk_HRP_patie");
            });

            modelBuilder.Entity<HrpPatientdiagnosticreportdtl>(entity =>
            {
                entity.ToTable("HRP_patientdiagnosticreportdtls");

                entity.HasIndex(e => e.VisitId, "HRP_patientdiagnosticreportdtls_visit_id_eab58f1d");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActiveYn)
                    .HasMaxLength(255)
                    .HasColumnName("active_yn");

                entity.Property(e => e.AttachPath)
                    .HasMaxLength(255)
                    .HasColumnName("attach_path");

                entity.Property(e => e.Conclusion)
                    .HasMaxLength(255)
                    .HasColumnName("conclusion");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.PanelCode)
                    .HasMaxLength(255)
                    .HasColumnName("panel_code");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(255)
                    .HasColumnName("patient_id");

                entity.Property(e => e.PerformingOrg)
                    .HasMaxLength(100)
                    .HasColumnName("performing_org");

                entity.Property(e => e.ReportCategory)
                    .HasMaxLength(255)
                    .HasColumnName("report_category");

                entity.Property(e => e.ReportCategoryValue)
                    .HasMaxLength(255)
                    .HasColumnName("report_category_value");

                entity.Property(e => e.ReportConclusion)
                    .HasMaxLength(1000)
                    .HasColumnName("report_conclusion");

                entity.Property(e => e.ReportDate).HasColumnName("report_date");

                entity.Property(e => e.ReportDt).HasColumnName("report_dt");

                entity.Property(e => e.ReportFilePath)
                    .HasMaxLength(1000)
                    .HasColumnName("report_file_path");

                entity.Property(e => e.ReportFileType)
                    .HasMaxLength(100)
                    .HasColumnName("report_file_type");

                entity.Property(e => e.ReportType)
                    .HasMaxLength(255)
                    .HasColumnName("report_type");

                entity.Property(e => e.ReportedBy)
                    .HasMaxLength(100)
                    .HasColumnName("reported_by");

                entity.Property(e => e.ReportingDoctor)
                    .HasMaxLength(255)
                    .HasColumnName("reporting_doctor");

                entity.Property(e => e.ServiceCategory)
                    .HasMaxLength(100)
                    .HasColumnName("service_category");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status");

                entity.Property(e => e.TestCode)
                    .HasMaxLength(100)
                    .HasColumnName("test_code");

                entity.Property(e => e.TestCodeValue)
                    .HasMaxLength(100)
                    .HasColumnName("test_code_value");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.HrpPatientdiagnosticreportdtls)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("HRP_patientdiagnosti_visit_id_eab58f1d_fk_HRP_patie");
            });

            modelBuilder.Entity<HrpPatientdischargenotesdtl>(entity =>
            {
                entity.ToTable("HRP_patientdischargenotesdtls");

                entity.HasIndex(e => e.VisitId, "HRP_patientdischargenotesdtls_visit_id_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdmissionDt).HasColumnName("admission_dt");

                entity.Property(e => e.AdviceDischarge)
                    .HasMaxLength(100000)
                    .HasColumnName("advice_discharge");

                entity.Property(e => e.AttachPath)
                    .HasMaxLength(255)
                    .HasColumnName("attach_path");

                entity.Property(e => e.Complaints)
                    .HasMaxLength(100000)
                    .HasColumnName("complaints");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Diagnosis)
                    .HasMaxLength(100000)
                    .HasColumnName("diagnosis");

                entity.Property(e => e.DischargeDt).HasColumnName("discharge_dt");

                entity.Property(e => e.DocumentBy)
                    .HasMaxLength(100)
                    .HasColumnName("document_by");

                entity.Property(e => e.DocumentCategory)
                    .HasMaxLength(100)
                    .HasColumnName("document_category");

                entity.Property(e => e.DocumentCreatedAt)
                    .HasMaxLength(100)
                    .HasColumnName("document_created_at");

                entity.Property(e => e.DocumentCreatedDt).HasColumnName("document_created_dt");

                entity.Property(e => e.DocumentSource)
                    .HasMaxLength(100)
                    .HasColumnName("document_source");

                entity.Property(e => e.DocumentStatus)
                    .HasMaxLength(100)
                    .HasColumnName("document_status");

                entity.Property(e => e.FollowUp)
                    .HasMaxLength(100000)
                    .HasColumnName("follow_up");

                entity.Property(e => e.Notes)
                    .HasMaxLength(100000)
                    .HasColumnName("notes");

                entity.Property(e => e.ProcedureDone)
                    .HasMaxLength(100000)
                    .HasColumnName("procedure_done");

                entity.Property(e => e.ReportType)
                    .HasMaxLength(255)
                    .HasColumnName("report_type");

                entity.Property(e => e.StatusDischarge)
                    .HasMaxLength(255)
                    .HasColumnName("status_discharge");

                entity.Property(e => e.TreatmentGiven)
                    .HasMaxLength(100000)
                    .HasColumnName("treatment_given");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.HasOne(d => d.Visit)
                    .WithOne(p => p.HrpPatientdischargenotesdtl)
                    .HasForeignKey<HrpPatientdischargenotesdtl>(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("HRP_patientdischarge_visit_id_59d0d0fc_fk_HRP_patie");
            });

            modelBuilder.Entity<HrpPatientprescriptiondtl>(entity =>
            {
                entity.ToTable("HRP_patientprescriptiondtls");

                entity.HasIndex(e => e.VisitId, "HRP_patientprescriptiondtls_visit_id_456ed92f");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActiveYn)
                    .HasMaxLength(255)
                    .HasColumnName("active_yn");

                entity.Property(e => e.AttachPath)
                    .HasMaxLength(255)
                    .HasColumnName("attach_path");

                entity.Property(e => e.Condition)
                    .HasMaxLength(200)
                    .HasColumnName("condition");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DrugId)
                    .HasMaxLength(100)
                    .HasColumnName("drug_id");

                entity.Property(e => e.DrugInstructionId).HasColumnName("drug_instruction_id");

                entity.Property(e => e.DrugName)
                    .HasMaxLength(100)
                    .HasColumnName("drug_name");

                entity.Property(e => e.Duration)
                    .HasMaxLength(100)
                    .HasColumnName("duration");

                entity.Property(e => e.DurationUnit)
                    .HasMaxLength(50)
                    .HasColumnName("duration_unit");

                entity.Property(e => e.Instruction)
                    .HasMaxLength(100000)
                    .HasColumnName("instruction");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.PresciptionDt).HasColumnName("presciption_dt");

                entity.Property(e => e.PresciptionNotes)
                    .HasMaxLength(100000)
                    .HasColumnName("presciption_notes");

                entity.Property(e => e.PrescribedBy)
                    .HasMaxLength(100)
                    .HasColumnName("prescribed_by");

                entity.Property(e => e.Quantity)
                    .HasMaxLength(10)
                    .HasColumnName("quantity");

                entity.Property(e => e.RepeatsAllowedYn)
                    .HasMaxLength(1)
                    .HasColumnName("repeats_allowed_yn");

                entity.Property(e => e.ReportType)
                    .HasMaxLength(255)
                    .HasColumnName("report_type");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.HrpPatientprescriptiondtls)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("HRP_patientprescript_visit_id_456ed92f_fk_HRP_patie");
            });

            modelBuilder.Entity<HrpPatientvisitdtl>(entity =>
            {
                entity.HasKey(e => e.VisitId)
                    .HasName("HRP_patientvisitdtls_pkey");

                entity.ToTable("HRP_patientvisitdtls");

                entity.HasIndex(e => e.PatientId, "HRP_patientvisitdtls_patient_id_37549735");

                entity.Property(e => e.VisitId)
                    .ValueGeneratedNever()
                    .HasColumnName("visit_id");

                entity.Property(e => e.ClinicalNotesYn)
                    .HasMaxLength(1)
                    .HasColumnName("clinical_notes_yn");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DiagnosticReportYn)
                    .HasMaxLength(1)
                    .HasColumnName("diagnostic_report_yn");

                entity.Property(e => e.DischargeSummaryYn)
                    .HasMaxLength(1)
                    .HasColumnName("discharge_summary_yn");

                entity.Property(e => e.FacilityCd)
                    .HasMaxLength(100)
                    .HasColumnName("facility_cd");

                entity.Property(e => e.FacilityName)
                    .HasMaxLength(100)
                    .HasColumnName("facility_name");

                entity.Property(e => e.FhirObject).HasColumnName("fhir_object");

                entity.Property(e => e.FhirPractitionerObject).HasColumnName("fhir_practitioner_object");

                entity.Property(e => e.LinkYn)
                    .HasMaxLength(1)
                    .HasColumnName("link_yn");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PractitionerCd)
                    .HasMaxLength(100)
                    .HasColumnName("practitioner_cd");

                entity.Property(e => e.PractitionerName)
                    .HasMaxLength(100)
                    .HasColumnName("practitioner_name");

                entity.Property(e => e.PrescriptionYn)
                    .HasMaxLength(1)
                    .HasColumnName("prescription_yn");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.VisitDt).HasColumnName("visit_dt");

                entity.Property(e => e.VisitType)
                    .HasMaxLength(100)
                    .HasColumnName("visit_type");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.HrpPatientvisitdtls)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("HRP_patientvisitdtls_patient_id_37549735_fk_HRP_patie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
