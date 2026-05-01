import { test, expect } from '@playwright/test';

test('pagina inicial carrega', async ({ page }) => {
  await page.goto('http://localhost:5173');
  await expect(page).toHaveTitle('web');
});

test('menu de navegação principal está visível', async ({ page }) => {
  await page.goto('http://localhost:5173');
  await expect(page.getByRole('navigation', { name: 'Main navigation' })).toBeVisible();
});

test('lista de transações está visível na página inicial', async ({ page }) => {
  await page.goto('http://localhost:5173');
  await expect(page.locator('table')).toBeVisible();
});