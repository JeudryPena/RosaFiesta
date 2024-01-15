import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
  name: 'filterOptions'
})
export class FilterOptionsPipe implements PipeTransform {

  transform(opts: any[], searchText: string): any[] {
    if (!opts) {
      return [];
    }
    if (!searchText) {
      return opts;
    }

    searchText = searchText.toLowerCase();
    return opts.filter(item => {
      return item.title.toLowerCase().includes(searchText);
    });
  }

}
