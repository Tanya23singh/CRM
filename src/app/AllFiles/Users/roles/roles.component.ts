import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PermissionComponent } from '../permission/permission.component';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})
export class RolesComponent {
head:string="User Roles"
constructor(private modalService: NgbModal) {}

onButtonClicked(){
this.openPopup()
}
openPopup() {
  const modalRef = this.modalService.open(PermissionComponent);
}

}
