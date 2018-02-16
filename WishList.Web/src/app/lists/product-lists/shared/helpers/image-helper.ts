import {ProductItem} from '../product-item.model';

export class ImageHelper {

  public static getVariantImage(productItem: ProductItem): string {
    if (productItem == null || productItem.Product == null || productItem.Product.images == null) {
      return '../../../../assets/images/empty-img.png';
    }

    for (const image of productItem.Product.images) {
      if (image.variant_ids.indexOf(productItem.VariantId) !== -1) {
        return image.src;
      }
    }

    return '../../../../assets/images/empty-img.png';
  }

  public static getProductImage(product: any, variant: any): string {
    if (!product || !product.images || product.images.length === 0) {
      return '/theme/img/product_default.jpg';
    }

    let currentImage = product.images[0].src;

    for (const img of product.images) {
      if (img.variant_ids) {
        for (const va of img.variant_ids) {
          if (va === variant.id) {
            currentImage = img.src;
            break;
          }
        }
      }
    }

    return currentImage;
  }

}
