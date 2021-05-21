using SportStore.Enums;

namespace SportStore.Entities
{
    public class StoreItem : BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public ItemType ItemType { get; set; }
    }
}
