import { useEffect, useState } from 'react'

export function formatPelican(n: number): string {
  return `pelican-${n}`
}

export function PelicanWidget({ start }: { start: number }) {
  const [count, setCount] = useState(start)
  useEffect(() => {
    const id = setInterval(() => setCount((c) => c + 1), 1000)
    return () => clearInterval(id)
  }, [])
  const label = formatPelican(count)
  return <button onClick={() => setCount(0)}>{label}</button>
}
