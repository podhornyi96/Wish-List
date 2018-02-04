using System.Runtime.Serialization;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Filters.Enums.FilterFields
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyProductVariantField>))]
    public enum ShopifyProductVariantField
    {
        [EnumMember(Value = "barcode")]
        Barcode,
        [EnumMember(Value = "id")]
        ID,
        [EnumMember(Value = "price")]
        Price,
        [EnumMember(Value = "product_id")]
        ProductId,
        [EnumMember(Value = "line_items")]
        LineItems,
        [EnumMember(Value = "sku")]
        Sku,
        [EnumMember(Value = "grams")]
        Grams,
        [EnumMember(Value = "inventory_management")]
        InventoryManagement,
        [EnumMember(Value = "inventory_policy")]
        InventoryPolicy,
        [EnumMember(Value = "inventory_quantity")]
        InventoryQuantity,
        [EnumMember(Value = "option1")]
        Option,
        [EnumMember(Value = "requires_shipping")]
        RequiresShipping,
        [EnumMember(Value = "taxable")]
        Taxable,
        [EnumMember(Value = "title")]
        Title,
        [EnumMember(Value = "weight")]
        Weight,
        [EnumMember(Value = "weight_unit")]
        WeightUnit,
        [EnumMember(Value = "fulfillment_service")]
        FulfillmentService,
        [EnumMember(Value = "image_id")]
        ImageId,
        [EnumMember(Value = "images")]
        Images
    }
}
