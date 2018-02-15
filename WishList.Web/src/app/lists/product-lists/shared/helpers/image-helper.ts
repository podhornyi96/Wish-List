import {ProductItem} from '../product-item.model';

export class ImageHelper {

  public static getVariantImage(productItem: ProductItem): string {

    for (const image of productItem.Product.images) {
      if (image.variant_ids.indexOf(productItem.VariantId) !== -1) {
        return image.src;
      }
    }

    return '../../../../assets/images/empty-img.png';
  }

}
