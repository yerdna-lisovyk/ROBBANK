using System;
using UnityEngine;

public class Traps
{
    public Traps(GameObject Cell, Card card)
    {
        switch (card.GetTypeTrap)
        {
            case Card.TypeTrap.CHIKA:
                {
                    Cell.AddComponent<ChikaTrap>().SetSprite(card.GetSprite);
                    break;
                }
            case Card.TypeTrap.MINA:
                {
                    Cell.AddComponent<Mina>().SetSprite(card.GetSprite);
                    break;
                }
            case Card.TypeTrap.VAGABOND:
                {
                    Cell.AddComponent<Vagabond>().SetSprite(card.GetSprite);
                    break;
                }
        }

    }


    public class ChikaTrap : MonoBehaviour
    {
        private ProfilePlayer _player;

        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.STOP;

        public Sprite GetSprite => _sprite;
        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            MassegeBox.StaticShowMassege("Ловушка", "Отдать Монету? Или Ждать 20 секунд.", Yes, No);
            Destroy(this);
        }
        private void Yes()
        {
            _player.ApplyCoinDamage(-1);
        }
        private void No()
        {
            StatusBar.StaticNewStatus(20, _effect, _player);
        }
    }

    public class Mina : MonoBehaviour
    {
        private ProfilePlayer _player;

        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.STOP;
        public Sprite GetSprite => _sprite;
        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            _player.ApplyCoinDamage(-3);
            StatusBar.StaticNewStatus(20, _effect, _player);
            Destroy(this);
        }
    }
    public class Stretching : MonoBehaviour
    {
        private ProfilePlayer _player;

        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.STOP;
        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            _player.ApplyCoinDamage(-3);
            StatusBar.StaticNewStatus(20, _effect, _player);
            Destroy(this);
        }
    }

    public class SwimmingDoll : MonoBehaviour
    {
        private ProfilePlayer _player;

        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.STOP;
        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            StatusBar.StaticNewStatus(30, _effect, _player);
            Destroy(this);
        }
    }
    public class Kitty : MonoBehaviour
    {
        private ProfilePlayer _player;

        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.STOP;
        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            StatusBar.StaticNewStatus(40, _effect, _player);
            Destroy(this);
        }
    }

    public class Barbecue : MonoBehaviour
    {
        private ProfilePlayer _player;

        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.STOP;
        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            StatusBar.StaticNewStatus(10, _effect, _player);
            Destroy(this);
        }
    }
    public class Sparrow : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;
        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            MassegeBox.StaticShowMassege("Воробей", "Птица спёрла монету. Потрать патрон или он улетит с монетой.", Yes, No);
            Destroy(this);
        }

        private void Yes()
        {
            _player.GetAmmo.AddAmmo(-1);
        }
        private void No()
        {
            _player.ApplyCoinDamage(-1);
        }
    }
    public class Stinky : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.NOTVISIBILITY;
        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            StatusBar.StaticNewStatus(40, _effect, _player);
            Destroy(this);
        }
    }

    public class TrafficPolice : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            if (_player.GetEquipment.SearchByEquipment(Card.NameEqupment.BOOTS_OF_SPEED))
            {
                _player.ApplyCoinDamage(-2);
            }
            Destroy(this);
        }
    }

    public class RepairWork : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;
        private PlayerMove _move;

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            _move = collision.GetComponent<PlayerMove>();
            MassegeBox.StaticShowMassege("Ремонтыне работы", "Заплати манету или жди минуту", Yes, No);
            Destroy(this);
        }
        private void Yes()
        {
            _player.ApplyCoinDamage(-1);
        }
        private void No()
        {
            _move.MoveToPoint(-1);
        }
    }

    public class Vagabond : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.VAGABOND;
        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            StatusBar.StaticNewStatus(10, _effect, _player);
            Destroy(this);
        }
    }

    public class Tiguli : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;
        private PlayerMove _move;
        private StatusBar.Effect _effect = StatusBar.Effect.STOP;

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            _move = collision.GetComponent<PlayerMove>();
            if (_player.IsActiveEffect(StatusBar.Effect.VAGABOND))
            {
                _move.MoveToPoint(1);
            }
            else
            {
                StatusBar.StaticNewStatus(20, _effect, _player);
            }
            Destroy(this);
        }
    }

    public class Pit : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.STOP;

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            StatusBar.StaticNewStatus(25, _effect, _player);
            Destroy(this);
        }
    }

    public class Rapper : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.STOP;

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            MassegeBox.StaticShowMassege("Рэпер", "Заставляет тебя слушать его музыку 10 секунд или откупись за 4 монеты", Yes, No);
            Destroy(this);
        }
        private void Yes()
        {
            _player.ApplyCoinDamage(-4);
        }
        private void No()
        {
            StatusBar.StaticNewStatus(10, _effect, _player);
        }
    }

    public class ShootingGallery : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            _player.GetAmmo.AddAmmo(-3);
            Destroy(this);
        }
    }

    public class Wind : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            if (_player.GetEquipment.SearchByEquipment(Card.NameEqupment.FOIL_CAP))
                _player.GetEquipment.AddHead(null);
            Destroy(this);
        }
    }

    public class Fitting : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.STOP;
        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            int second=0;
            if (_player.GetEquipment.GetBody != null)
                second += 2;
            if (_player.GetEquipment.GetHead != null)
                second += 2;
            if (_player.GetEquipment.GetWeapon != null)
                second += 2;
            foreach(var bot in _player.GetEquipment.GetBoots)
            {
                if (bot != null)
                    second += 2;
            }
            StatusBar.StaticNewStatus(second, _effect, _player);
            Destroy(this);
        }
    }

    public class Flash : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.NOTVISIBILITY;

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            if (_player.GetEquipment.SearchByEquipment(Card.NameEqupment.WELDER_GOGGLES))
                StatusBar.StaticNewStatus(10, _effect, _player);
            Destroy(this);
        }
    }

    public class Nail : MonoBehaviour // стулл с гвоздями доделать
    {
        private ProfilePlayer _player;
        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.STOP;

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            MassegeBox.StaticShowMassege("Стул с гвоздями", "Тебя приковали к стулу на 10 секунд. Можешь выбраться применив плоскогубцы", Yes, No);
            Destroy(this);
        }
        private void Yes()
        {
            
        }
        private void No()
        {
            StatusBar.StaticNewStatus(10, _effect, _player);
        }

    }

    public class Huckster : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            MassegeBox.StaticShowMassege("Барыга", "Отдай 3 монеты или потеряй рандомную вещь", Yes, No);
            Destroy(this);
        }

        private void Yes()
        {
            _player.ApplyCoinDamage(-3);
        }
        private void No()
        {
            _player.GetEquipment.RemoveRandEquip();
        }
    }
}
