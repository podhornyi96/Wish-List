export class ProductItem {

  ProductListId: number;
  ProductId: number;
  VariantId: number;
  Product: any; // TODO add type

  constructor(obj?: Partial<ProductItem>) {
    Object.assign(this, obj);
  }

}
