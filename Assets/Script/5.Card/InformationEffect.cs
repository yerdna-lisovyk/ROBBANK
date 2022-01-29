using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InformationEffect
{
    public static class Vagabon
    {
        public static bool _massgeYes;

        public static void VagabonMassage(ProfilePlayer player)
        {
            _massgeYes = false;
            MassegeBox.StaticShowMassege("Бомж", "Отдайте одежду или посмотрите рекламу", () =>
            {
                player.GetEquipment.AddBody(null);
                player.DestroyStatus(StatusBar.Effect.VAGABOND);
                _massgeYes = true;
    
            }, () =>
            {
                _massgeYes = true;
                player.DestroyStatus(StatusBar.Effect.VAGABOND);
            }
            , true);
        }
    }


}
