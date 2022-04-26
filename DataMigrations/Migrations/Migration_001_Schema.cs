using FluentMigrator;

namespace DataMigrations.Migrations
{
    [Migration(1, "Set up the database schema")]
    public class Migration_001_Schema : ForwardOnlyMigration
    {
        public override void Up()
        {
            this.Create.Table("Banka")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Ime").AsString().NotNullable();

            this.Create.Table("Proizvod")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Ime").AsString().NotNullable();

            this.Create.Table("InformacijeOIsporuci")
                .WithColumn("Id").AsGuid().PrimaryKey().Nullable()
                .WithColumn("Ime").AsString().NotNullable();

            this.Create.Table("Ponudjac")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Ime").AsString();

            this.Create.Table("JavniPoziv")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Ime").AsString().NotNullable();

            this.Create.Table("StavkaStruktureCene")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Kolicina").AsInt32().NotNullable()
                .WithColumn("JedinicnaCenaSaPdv").AsDouble().NotNullable()
                .WithColumn("JedinicnaCenaBezPdv").AsDouble().NotNullable()
                .WithColumn("ProizvodId").AsGuid().NotNullable()
                .WithColumn("PonudaId").AsGuid().NotNullable();

            this.Create.Table("TekuciRacunPonudjaca")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("BrojRacuna").AsString().NotNullable()
                .WithColumn("PonudaId").AsGuid().NotNullable()
                .WithColumn("BankaId").AsGuid().NotNullable();

            this.Create.Table("Ponuda")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Status").AsString().NotNullable()
                .WithColumn("DatumPristizanja").AsDateTime().NotNullable()
                .WithColumn("ZakonskiZastupnik").AsString().NotNullable()
                .WithColumn("Kontakt_Ime").AsString().NotNullable()
                .WithColumn("Kontakt_Prezime").AsString().NotNullable()
                .WithColumn("Kontakt_Jmbg").AsFixedLengthString(13).NotNullable()
                .WithColumn("Kontakt_Email").AsString()
                .WithColumn("Kontakt_Telefon").AsString()
                .WithColumn("PonudjacId").AsGuid().NotNullable()
                .WithColumn("JavniPozivId").AsGuid().NotNullable()
                .WithColumn("InformacijeOIsporuciId").AsGuid().NotNullable();

            this.Create.ForeignKey().FromTable("Ponuda").ForeignColumn("PonudjacId").ToTable("Ponudjac").PrimaryColumn("Id");
            this.Create.ForeignKey().FromTable("Ponuda").ForeignColumn("JavniPozivId").ToTable("JavniPoziv").PrimaryColumn("Id");
            this.Create.ForeignKey().FromTable("Ponuda").ForeignColumn("InformacijeOIsporuciId").ToTable("InformacijeOIsporuci").PrimaryColumn("Id");

            this.Create.ForeignKey().FromTable("StavkaStruktureCene").ForeignColumn("PonudaId").ToTable("Ponuda").PrimaryColumn("Id");
            this.Create.ForeignKey().FromTable("StavkaStruktureCene").ForeignColumn("ProizvodId").ToTable("Proizvod").PrimaryColumn("Id");
            
            this.Create.ForeignKey().FromTable("TekuciRacunPonudjaca").ForeignColumn("PonudaId").ToTable("Ponuda").PrimaryColumn("Id");
            this.Create.ForeignKey().FromTable("TekuciRacunPonudjaca").ForeignColumn("BankaId").ToTable("Banka").PrimaryColumn("Id");


        }
    }
}
