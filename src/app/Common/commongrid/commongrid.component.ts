import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-commongrid',
  templateUrl: './commongrid.component.html',
  styleUrls: ['./commongrid.component.css']
})
export class CommongridComponent {
  @Input() text:any;

}
