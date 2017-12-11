import {
    MatButtonModule, 
    MatCheckboxModule,
    MatCardModule,
    MatToolbarModule
} from '@angular/material';
import { NgModule } from '@angular/core';

@NgModule({
  imports: [MatButtonModule, MatCheckboxModule, MatCardModule, MatToolbarModule],
  exports: [MatButtonModule, MatCheckboxModule, MatCardModule, MatToolbarModule],
})
export class MaterialModule { }