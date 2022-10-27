import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinner, NgxSpinnerModule } from 'ngx-spinner';

@NgModule({
  imports: [
    CommonModule,
    TabsModule.forRoot(),
    NgxGalleryModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    NgxSpinnerModule,
  ],
  declarations: [],
  exports: [
    TabsModule,
    NgxGalleryModule,
    BsDropdownModule,
    ToastrModule,
    NgxSpinnerModule
  ]
})
export class SharedModule { }