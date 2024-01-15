import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
  name: 'filterProducts'
})
export class FilterProductsPipe implements PipeTransform {

  transform(opts: any[], searchText: string): any[] {
    if (!opts) {
      return [];
    }
    if (!searchText) {
      return opts;
    }

    searchText = searchText.toLowerCase();
    return opts.filter(item => {
      return item.option.title.toLowerCase().includes(searchText);
    });
  }

}
