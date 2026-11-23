export function tapirCaller(n: number): number {
  return tapirLocal(n) + 1
}

function tapirLocal(n: number): number {
  return n * 3
}
