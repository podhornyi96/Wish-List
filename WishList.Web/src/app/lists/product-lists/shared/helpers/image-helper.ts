export class ImageHelper {

  public static getProductImage(product: any, variantId: number): string {
    if (!product || !product.images || product.images.length === 0) {
      return '../../../../assets/images/empty-img.png';
    }

    let currentImage = product.images[0].src;

    for (const img of product.images) {
      if (img.variant_ids) {
        for (const va of img.variant_ids) {
          if (va === variantId) {
            currentImage = img.src;
            break;
          }
        }
      }
    }

    return currentImage;
  }

}
