import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner/lib/ngx-spinner.service';
import { ToastrService } from 'ngx-toastr';
import { CustomToastrService, ToastrMessageType } from './services/ui/custom-toastr.service';


declare var $: any

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ECommerceClient';
 
  constructor(private toastrService: CustomToastrService) {
 toastrService.message("Merhaba"," Burak",ToastrMessageType.Success)  }
}
