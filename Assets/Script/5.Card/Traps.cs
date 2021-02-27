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
            MassegeBox.StaticShowMassege("Воробей", "Птица спёрла монету. Потрать патрон или он улетит с монетой.",Yes,No);
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
            if(_player.GetEquipment.SearchByEquipment(Card.NameEqupment.BOOTS_OF_SPEED))
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
            _move.BackMove(1);
        }
    }

    public class Vagabond: MonoBehaviour
    {
        private ProfilePlayer _player;
        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.TOOKDAMAGE;
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
}
