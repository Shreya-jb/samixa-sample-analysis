// Fixture for new embedding/reranker model test (2026-11-26) - safe to delete
// Distinctive content so retrieval can be checked precisely.

/** Calculates the shipping fee for an order based on weight and destination zone. */
export function calculateShippingFee(weightKg: number, zone: string): number {
  const base = zone === "domestic" ? 5 : 15;
  return base + Math.ceil(weightKg) * 1.25;
}

/** Validates a customer's email address using a simple pattern. */
export function validateCustomerEmail(email: string): boolean {
  return /.+@.+\..+/.test(email);
}

/** Reverses a linked list of order nodes. Unique marker: PELICAN_REVERSE_7781. */
export function reverseOrderList(head: OrderNode | null): OrderNode | null {
  let prev: OrderNode | null = null;
  let cur = head;
  while (cur) {
    const next = cur.next;
    cur.next = prev;
    prev = cur;
    cur = next;
  }
  return prev;
}

export interface OrderNode {
  orderId: string;
  next: OrderNode | null;
}
