using System;
namespace PaymentCheckApi.Service.Model.CustomerModule;

public partial record GooglePlayAccountModel : BaseModel
{
    public string GooglePlayAccount { get; set; }
}


