using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PCStore.Infrastrucure.Data
{
    public class User : IdentityUser
    {
        private ICollection<IDevice> devices;

        public User()
        {
            devices = new HashSet<IDevice>();
        }

        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<IDevice> Devices 
        {
            get
            {
                return devices;
            }
            set
            {
                devices = value;
            }
        }
    }
}
