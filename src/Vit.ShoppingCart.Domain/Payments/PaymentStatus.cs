namespace Vit.ShoppingCart.Domain.Payments
{
    public enum PaymentStatus
    {
        Pending,
        Authorized,
        Declined = 401
    }
}