export class StringHelper {

  public static getParameterByName(name: string): string {
    const url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');
    const regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
      results = regex.exec(url);
    if (!results) {
      return null;
    }
    if (!results[2]) {
      return '';
    }

    return decodeURIComponent(results[2].replace(/\+/g, ' '));
  }

  public static replaceHttpPrefix(uri: string): string {
    return uri.replace(/(^\w+:|^)\/\//, '');
  }

  public static isNullOrEmpty(value: string): boolean {
    if (value != null && typeof value === 'number') {
      return false;
    }

    return (value == null || (value === '') || value.length === 0);
  }

}
