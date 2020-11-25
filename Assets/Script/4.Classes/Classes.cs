using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes : MonoBehaviour
{
    public class officer : OfficerFeature
    {
        private const string Name = "Оффицер";
        private const string Description = "Может играть две карты сразу если выбросит 5 или 6";

        public officer()
        {
           AttachAnEvent();
        }
        public string GetName => Name;
        public string GetDescription => Description;
    }

    public class schoolboy
    {
        private const string Name = "Школьник";
        private const string Description = "Если остается последняя монета, и ее хотят забрать может кинуть кубик и если выпадет больше 4х то сохранит себе жизнь.";
        public schoolboy()
        {

        }
        public string GetName => Name;
        public string GetDescription => Description;
    }

    public officer TakeClasses()
    {
        return new officer();
    }
}
