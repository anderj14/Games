import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsoleItemsComponent } from './console-items.component';

describe('ConsoleItemsComponent', () => {
  let component: ConsoleItemsComponent;
  let fixture: ComponentFixture<ConsoleItemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsoleItemsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConsoleItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
