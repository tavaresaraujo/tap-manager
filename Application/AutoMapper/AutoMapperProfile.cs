using AutoMapper;

namespace Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            Mapper.Initialize(profile => {
                profile.AddProfile<MerchantProfile>();
                profile.AddProfile<AccountProfile>();
                profile.AddProfile<PhoneProfile>();
                profile.AddProfile<AddressProfile>();
            });
        }
    }
}
