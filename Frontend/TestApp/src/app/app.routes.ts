import { Routes } from '@angular/router';
import { LayoutComponent } from './shared/components/layout/layout.component';
import { ResultComponent } from './features/result/components/result.component';
import { HistoryComponent } from './features/history/components/history.component';

export const routes: Routes = [
    {
        path: '', component: LayoutComponent, children: [
            { path: '', redirectTo: 'results', pathMatch: 'full' },
            { path: 'results', component: ResultComponent, title: 'Resultado', runGuardsAndResolvers: 'always' },
            { path: 'history', component: HistoryComponent, title: 'Historial', runGuardsAndResolvers: 'always' }
        ]
    }
];
