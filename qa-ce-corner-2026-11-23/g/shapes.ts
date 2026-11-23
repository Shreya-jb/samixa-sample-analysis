export default function (x: number): number {
  return x * 2
}

export function overloaded(a: string): string
export function overloaded(a: number): number
export function overloaded(a: string | number): string | number {
  return a
}

export abstract class Shape {
  abstract area(): number
  get label(): string {
    return 'shape'
  }
  set label(v: string) {
    void v
  }
  static create(): Shape | null {
    return null
  }
}

export async function* streamOtters(n: number) {
  for (let i = 0; i < n; i++) yield i
}

export const enum Color { Red, Green }

export namespace Geometry {
  export function distance(a: number, b: number): number {
    return Math.abs(a - b)
  }
}

export const handlers = {
  onOtter: (x: number) => x + 1,
  onBadger(x: number) {
    return x - 1
  },
}

export class Café {
  ünïcode(): string {
    return 'ü'
  }
}
