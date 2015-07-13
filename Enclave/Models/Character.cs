namespace Enclave.Models
{
    internal class Character
    {
        public string Name;
        public int Location;
        public Archetype Archetype;
        private bool _dead = false;
        private bool _inLove = false;
        private Diary _diary;
        private Player _player;
    }
}