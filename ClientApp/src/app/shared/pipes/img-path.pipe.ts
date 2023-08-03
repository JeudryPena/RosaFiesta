import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'imgPath'
})
export class ImgPathPipe implements PipeTransform {

  transform(image: any): string {
    return `https://localhost:7136/${image.image}`;
  }
}
