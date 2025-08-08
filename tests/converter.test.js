const request = require('supertest');
const app = require('../app'); // Assuming your Express app is in app.js

describe('Number to Words Converter API', () => {
  test('converts 0 to words', async () => {
    const response = await request(app)
      .post('/api/convert')
      .send({ number: '0' });
    expect(response.statusCode).toBe(200);
    expect(response.body.result).toBe('ZERO DOLLARS');
  });

  test('converts whole numbers to words', async () => {
    const response = await request(app)
      .post('/api/convert')
      .send({ number: '123' });
    expect(response.statusCode).toBe(200);
    expect(response.body.result).toBe('ONE HUNDRED AND TWENTY-THREE DOLLARS');
  });

  test('converts decimal numbers to words', async () => {
    const response = await request(app)
      .post('/api/convert')
      .send({ number: '123.45' });
    expect(response.statusCode).toBe(200);
    expect(response.body.result).toBe('ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS');
  });

  test('handles invalid input', async () => {
    const response = await request(app)
      .post('/api/convert')
      .send({ number: 'abc' });
    expect(response.statusCode).toBe(400);
    expect(response.body).toHaveProperty('error');
  });

  test('converts large numbers', async () => {
    const response = await request(app)
      .post('/api/convert')
      .send({ number: '1234567.89' });
    expect(response.statusCode).toBe(200);
    expect(response.body.result).toBe('ONE MILLION TWO HUNDRED AND THIRTY-FOUR THOUSAND FIVE HUNDRED AND SIXTY-SEVEN DOLLARS AND EIGHTY-NINE CENTS');
  });
});
