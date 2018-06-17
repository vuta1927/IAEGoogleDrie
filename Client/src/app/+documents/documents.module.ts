import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { routes } from './documents.routing';
import { DocumentsComponent } from './documents.component';
@NgModule({
    imports: [
        SharedModule, 
        RouterModule.forChild(routes),
    ],
    declarations: [DocumentsComponent],
})

export class DocumentsModule {}