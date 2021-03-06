import { Routes } from '@angular/router';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { ThemeComponent } from './shared/components/theme.component';

export const ROUTES: Routes = [
  {
    path: '',
    component: ThemeComponent,
    data: { pageTitle: 'Home' },
    canActivate: [AuthGuard],
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      {
        path: 'dashboard',
        loadChildren: 'app/+dashboard/dashboard.module#DashboardModule',
        data: { pageTitle: 'Dashboard' }
      },
      {
        path: 'administrator',
        loadChildren: 'app/+administrator/administrator.module#AdministratorModule',
        data: { pageTitle: 'Administrator' }
      },
      {
        path: 'documents',
        loadChildren: 'app/+documents/documents.module#DocumentsModule',
        data: { pageTitle: 'Documents' }
      },
      {
        path: '404',
        loadChildren: 'app/shared/components/pages/default/not-found/not-found.module#NotFoundModule'
      }
    ]
  },

  {
    path: 'account',
    loadChildren: 'app/+account/account.module#AccountModule'
  },

  { 
    path: '**',
    redirectTo: '404',
    pathMatch: 'full'
  }
];
