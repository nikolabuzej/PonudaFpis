using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .WithColumn("PonudaId").AsGuid().NotNullable()
                .WithColumn("Kolicina").AsInt32().NotNullable()
                .WithColumn("JedinicnaCenaSaPdv").AsDouble().NotNullable()
                .WithColumn("JedinicnaCenaBezPdv").AsDouble().NotNullable()
                .WithColumn("ProizvodId").AsGuid().NotNullable();

            this.Create.Table("TekuciRacunPonudjaca")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("PonudaId").AsGuid().NotNullable()
                .WithColumn("BrojRacuna").AsString().NotNullable()
                .WithColumn("BankaId").AsGuid().NotNullable();

            this.Create.Table("Ponuda")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Status");
        }
    }
}
