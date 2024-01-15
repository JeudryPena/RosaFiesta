import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
  name: 'filterRoles'
})
export class FilterRolesPipe implements PipeTransform {

  transform(opts: any[], searchText: string): any[] {
    if (!opts) {
      return [];
    }
    if (!searchText) {
      return opts;
    }

    searchText = searchText.toLowerCase();
    return opts.filter(item => {
      return item.name.toLowerCase().includes(searchText);
    });
  }

}
