import { CommonModule } from '@angular/common';
import { AfterViewInit, Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TopMenuComponent } from '../top-menu/top-menu.component';
import { NavMenuComponent } from '../nav-menu/nav-menu.component';
import { FooterComponent } from '../footer/footer.component';
import { RightSidebarComponent } from "../right-sidebar/right-sidebar.component";

@Component({
  selector: 'app-layout',
  imports: [CommonModule, RouterModule, TopMenuComponent, NavMenuComponent, FooterComponent, RightSidebarComponent, RightSidebarComponent],
  templateUrl: './layout.component.html',
})
export class LayoutComponent implements AfterViewInit {
  ngAfterViewInit() {
    const scripts: string[] = [
      '../assets/js/app.js',
      '../assets/libs/pace-js/pace.min.js'
    ];

    scripts.forEach((s) => {
      const script = document.createElement('script');
      script.src = s;
      document.body.appendChild(script);
    });

  }
}
