import {Component, bootstrap, CORE_DIRECTIVES} from 'angular2/angular2';
@Component({
    selector: 'my-app',
    template: `
    <h1>{{title}}</h1>
    <h2>{{myLocation}}</h2>
    <p>Drives:</p>
    <ul>
      <li *ng-for="#drive of drives">
        {{ drive }}
      </li>
    </ul>
    `,
    directives: [CORE_DIRECTIVES]
})

export class AppComponent {
  title = 'Hatish Test';
  myLocation = 'C:\\';
  drives = ['C', 'D', 'E'];
}
bootstrap(AppComponent);
