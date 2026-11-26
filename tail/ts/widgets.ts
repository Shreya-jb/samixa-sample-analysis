export abstract class Widget {
  abstract render(): string;
  describe(): string {
    return `Widget ${this.render()}`;
  }
}

export class Button extends Widget {
  constructor(private label: string) {
    super();
  }
  render(): string {
    return `[${this.label}]`;
  }
}

export function first<T>(arr: T[]): T | undefined {
  return arr[0];
}

export async function loadAll(urls: string[]): Promise<string[]> {
  return Promise.all(urls.map((u) => fetch(u).then((r) => r.text())));
}
