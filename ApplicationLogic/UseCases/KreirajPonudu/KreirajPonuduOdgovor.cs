﻿using ApplicationLogic.Abstractions.UseCase;
using Core.Domain.PonudaAggregate;

namespace ApplicationLogic.UseCases.KreirajPonudu
{
    public class KreirajPonuduOdgovor: IResponse
    {
        public KreirajPonuduOdgovor(Ponuda ponuda)
        {
            Ponuda = ponuda;
        }

        public Ponuda Ponuda { get; init; } = Ponuda.Default();
    }
}
