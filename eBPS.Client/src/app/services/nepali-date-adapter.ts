import { Injectable } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import NepaliDate from 'nepali-date-converter';

@Injectable({ providedIn: 'root' })
export class NepaliDateAdapter extends DateAdapter<NepaliDate> {
  getFirstDayOfWeek(): number {
    return 0; // Sunday
  }

  getNumDaysInMonth(date: NepaliDate): number {
    const daysInMonth = [32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32];
    return daysInMonth[date.getMonth()];
  }

  parse(value: any): NepaliDate | null {
    try {
      return typeof value === 'string' 
        ? NepaliDate.parse(value) 
        : null;
    } catch {
      return null;
    }
  }

  format(date: NepaliDate, displayFormat: any): string {
    // Ensure displayFormat is a string, fallback to default
    const safeFormat = typeof displayFormat === 'string' ? displayFormat : 'YYYY/MM/DD';
    
    try {
      return date.format(safeFormat);
    } catch {
      // Fallback to basic formatting if format method fails
      return `${date.getYear()}/${date.getMonth() + 1}/${date.getDate()}`;
    }
  }

  getYear(date: NepaliDate): number {
    return date.getYear();
  }

  getMonth(date: NepaliDate): number {
    return date.getMonth();
  }

  getDate(date: NepaliDate): number {
    return date.getDate();
  }

  getDayOfWeek(date: NepaliDate): number {
    return date.getDay();
  }

  getMonthNames(): string[] {
    return [
      'बैशाख', 'जेठ', 'असार', 'श्रावण', 'भाद्र', 'आश्विन',
      'कार्तिक', 'मंसिर', 'पुष', 'माघ', 'फाल्गुण', 'चैत'
    ];
  }

  getDateNames(): string[] {
    return Array.from({length: 32}, (_, i) => String(i + 1));
  }

  getDayOfWeekNames(): string[] {
    return ['आइत', 'सोम', 'मंगल', 'बुध', 'बिही', 'शुक्र', 'शनि'];
  }

  getYearName(date: NepaliDate): string {
    return date.getYear().toString();
  }

  createDate(year: number, month: number, date: number): NepaliDate {
    return new NepaliDate(year, month, date);
  }

  today(): NepaliDate {
    return NepaliDate.now();
  }

  invalid(): NepaliDate {
    return NepaliDate.now();
  }

  isDateInstance(obj: any): boolean {
    return obj instanceof NepaliDate;
  }

  isValid(date: NepaliDate): boolean {
    try {
      return date.getYear() > 0 && 
             date.getMonth() >= 0 && 
             date.getMonth() < 12 && 
             date.getDate() > 0;
    } catch {
      return false;
    }
  }

  clone(date: NepaliDate): NepaliDate {
    return new NepaliDate(date.getYear(), date.getMonth(), date.getDate());
  }

  addCalendarYears(date: NepaliDate, years: number): NepaliDate {
    const newDate = this.clone(date);
    newDate.setYear(date.getYear() + years);
    return newDate;
  }

  addCalendarMonths(date: NepaliDate, months: number): NepaliDate {
    const newDate = this.clone(date);
    newDate.setMonth(date.getMonth() + months);
    return newDate;
  }

  addCalendarDays(date: NepaliDate, days: number): NepaliDate {
    const newDate = this.clone(date);
    newDate.setDate(date.getDate() + days);
    return newDate;
  }

  toIso8601(date: NepaliDate): string {
    return date.toJsDate().toISOString();
  }
}