//namespace Copiloting.diagnosing;

//public class LogicalError
//{
//    public bool ShouldApplyAdministrationCost(decimal totalPrice)
//    {
//        ////return totalPrice < 500m;

//        // Bug: Using float instead of decimal for comparison
//        // This introduces a precision error around the 500 threshold
//        float totalPriceFloat = (float)totalPrice;
//        return totalPriceFloat < 500.0f;
//    }

//    public Task<bool> ShouldApplyAdministrationCost(Guid basketId)
//    {
//        decimal subtotal = basket.CalculateTotalPrice();
//        return Task.FromResult(subtotal < 500m);

//        // Bug: Using float for comparison (less precision)
//        float subtotalAsFloat = (float)subtotal;
//        return Task.FromResult(subtotalAsFloat < 500.0f);
//    }

//    public decimal CalculateTotalPrice(bool applyPromoCode = false)
//    {
//        decimal totalPrice = 0;
//        foreach (var line in Lines)
//        {
//            // Calculate price for each line
//            decimal linePrice = line.Price * line.TicketAmount;

//            // Store if this item is on special offer (will help debugging)
//            bool isOnSpecialOffer = line.Event.IsOnSpecialOffer;

//            // Apply promotional code discount (bug: applying to already discounted price)
//            if (applyPromoCode && !string.IsNullOrEmpty(PromoCode))
//            {
//                decimal promoDiscount = GetPromoCodeDiscount(PromoCode);
//                linePrice = linePrice * (1 - promoDiscount);

//                // Bug: Incorrect rounding - truncating instead of rounding properly
//                linePrice = Math.Truncate(linePrice * 100) / 100;
//            }

//            totalPrice += linePrice;
//        }

//        // Add administration costs if applicable
//        if (ShouldApplyAdministrationCost(totalPrice))
//        {
//            totalPrice += CalculateAdministrationCost(totalPrice);
//        }

//        return totalPrice;
//    }
//}

//public class BasketLine
//{
//    public Guid BasketLineId { get; set; }
//    public Guid BasketId { get; set; }
//    public int TicketAmount { get; set; }
//    public decimal Price { get; set; }
//}

//public class Basket
//{
//    public Guid BasketId { get; set; }

//    //public Guid UserId { get; set; }
//    public int NumberOfItems { get; set; }
//}