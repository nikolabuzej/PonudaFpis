using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMigrations.Migrations
{
    [Migration(2, "Add seed data to the database")]
    public class Migration_002_Init_Data : ForwardOnlyMigration
    {
        public override void Up()
        {
            UbaciBanke();
            UbaciJavnePozive();
            UbaciProizvode();
            UbaciPonudjace();
            UbaciInformacijeOIsporuci();
        }
        private void UbaciProizvode()
        {
            this.Insert.IntoTable("Proizvod")
                .Row(new
                {
                    Id = new Guid("0462d212-f698-4c55-a59c-2aa4d0b48f65"),
                    Ime = "Laptop"
                })
                .Row(new
                {
                    Id = new Guid("d8af357a-9e13-448b-af0f-af63c542f0c8"),
                    Ime = "Racunar"
                })
                .Row(new
                {
                    Id = new Guid("6fc70085-86d2-4dae-b4dd-8a6f0071bece"),
                    Ime = "Monitor"
                })
                .Row(new
                {
                    Id = new Guid("b4e95fec-69c0-448b-a774-2917efb5f937"),
                    Ime = "Stampac"
                })
                .Row(new
                {
                    Id = new Guid("23b5edfb-4b02-46d8-8053-3fbbab2a723c"),
                    Ime = "Skener"
                });
        }
        private void UbaciPonudjace()
        {
            this.Insert.IntoTable("Ponudjac")
                .Row(new
                {
                    Id = new Guid("5790711d-d004-4af0-94eb-670bcafa9dae"),
                    Ime = "Tehnomanija"
                })
                .Row(new
                {
                    Id = new Guid("0238bda6-4c0e-4de7-b14e-108346753368"),
                    Ime = "Gigatron"
                })
                .Row(new
                {
                    Id = new Guid("21e99f80-baea-4de3-b524-05a9101cef61"),
                    Ime = "WinWin"
                });
        }
        private void UbaciInformacijeOIsporuci()
        {
            this.Insert.IntoTable("InformacijeOIsporuci")
                .Row(new
                {
                    Id = new Guid("4eeb986c-2710-4e16-91c0-1341a640671e"),
                    Ime = "Informacije o isporuci jedan"
                })
                .Row(new
                {
                    Id = new Guid("05b689a7-b8f8-4c57-aa2e-dfeed03c6118"),
                    Ime = "Informacije o isporuci dva"
                });
        }
        private void UbaciJavnePozive()
        {
            this.Insert.IntoTable("JavniPoziv")
                .Row(new
                {
                    Id = new Guid("1a35fab0-8c25-42d5-9e6a-8b8513bf8bfb"),
                    Ime = "Januarski poziv"
                })
                .Row(new
                {
                    Id = new Guid("f8914041-4d53-48ae-a1d9-5280dd307e0a"),
                    Ime = "Martovski poziv"
                })
                .Row(new
                {
                    Id = new Guid("af89b4e0-1ea0-49e3-a323-c1fa3ec82b66"),
                    Ime = "Junski poziv"
                });
        }
        private  void UbaciBanke()
        {
            this.Insert.IntoTable("Banka")
              .Row(new
              {
                  Id = new Guid("fe933163-7f9e-4080-b5da-6518dac0be0d"),
                  Ime = "Intesa"
              })
              .Row(new
              {
                  Id = new Guid("3380bb78-45ab-4bcf-9feb-4900a42ef01e"),
                  Ime = "Aik"
              })
              .Row(new
              {
                  Id = new Guid("11dd4204-9503-437a-8045-78709726c598"),
                  Ime = "Credit Agricole"
              });
        }
    }
}
