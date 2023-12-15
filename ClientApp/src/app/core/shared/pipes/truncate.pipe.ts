import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'truncate'
})
export class TruncatePipe implements PipeTransform {

  transform(value: string | null, limit = 100): string {
    if (value === null) {
      return '';
    }
    if (value.length > limit) {
      return value.substring(0, limit) + '...';
    }
    return value;
  }

  // transform(text: string | null, limit: number): string {
  //   if (!text) return '';
  //   if (text.length <= limit) return text;

  //   const words = text.split(' ');
  //   let result = '';
  //   for (let i = 0; i < limit; i++) {
  //     result += words[i] + ' ';
  //   }
  //   result += '...';
  //   return result;
  // }

}
