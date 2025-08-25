import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <footer class="footer">
      <div class="container-fluid">
        <div class="row">
          <div class="col-sm-6">
            {{ date }} © 
          </div>
          <div class="col-sm-6">
            <div class="text-sm-end d-none d-sm-block">
              Develop by Juan David Rosas
            </div>
          </div>
        </div>
      </div>
    </footer>
  `
})
export class FooterComponent {
  date = new Date().getFullYear();
}
