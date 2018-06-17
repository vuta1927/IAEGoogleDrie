import { Routes } from '@angular/router';
import { AuthGuard } from '../shared/guards/auth.guard';
import { DefaultComponent } from '../shared/components/pages/default/default.component';
import { DocumentsComponent } from './documents.component';
export const routes: Routes = [
    {
        path: '',
        component: DefaultComponent,
        canActivate: [AuthGuard],
        children: [
            {
                path: '',
                component: DocumentsComponent
            }
        ]
    }
]