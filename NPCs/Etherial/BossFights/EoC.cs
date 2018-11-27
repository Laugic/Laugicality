/*{
									if (this.target < 0 || this.target == 255 || Main.player[this.target].dead || !Main.player[this.target].active)
									{
										this.TargetClosest(true);
									}
									bool dead3 = Main.player[this.target].dead;
									float num418 = this.position.X + (float)(this.width / 2) - Main.player[this.target].position.X - (float)(Main.player[this.target].width / 2);
									float num419 = this.position.Y + (float)this.height - 59f - Main.player[this.target].position.Y - (float)(Main.player[this.target].height / 2);
									float num420 = (float)Math.Atan2((double)num419, (double)num418) + 1.57f;
									if (num420 < 0f)
									{
										num420 += 6.283f;
									}
									else if ((double)num420 > 6.283)
									{
										num420 -= 6.283f;
									}
									float num421 = 0.15f;
									if (this.rotation < num420)
									{
										if ((double)(num420 - this.rotation) > 3.1415)
										{
											this.rotation -= num421;
										}
										else
										{
											this.rotation += num421;
										}
									}
									else if (this.rotation > num420)
									{
										if ((double)(this.rotation - num420) > 3.1415)
										{
											this.rotation += num421;
										}
										else
										{
											this.rotation -= num421;
										}
									}
									if (this.rotation > num420 - num421 && this.rotation < num420 + num421)
									{
										this.rotation = num420;
									}
									if (this.rotation < 0f)
									{
										this.rotation += 6.283f;
									}
									else if ((double)this.rotation > 6.283)
									{
										this.rotation -= 6.283f;
									}
									if (this.rotation > num420 - num421 && this.rotation < num420 + num421)
									{
										this.rotation = num420;
									}
									if (Main.rand.Next(5) == 0)
									{
										int num422 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height * 0.25f), this.width, (int)((float)this.height * 0.5f), 5, this.velocity.X, 2f, 0, default(Color), 1f);
										Dust var_9_15364_cp_0_cp_0 = Main.dust[num422];
										var_9_15364_cp_0_cp_0.velocity.X = var_9_15364_cp_0_cp_0.velocity.X * 0.5f;
										Dust var_9_15388_cp_0_cp_0 = Main.dust[num422];
										var_9_15388_cp_0_cp_0.velocity.Y = var_9_15388_cp_0_cp_0.velocity.Y * 0.1f;
									}
									if (Main.netMode != 1 && !Main.dayTime && !dead3 && this.timeLeft < 10)
									{
										int num;
										for (int num423 = 0; num423 < 200; num423 = num + 1)
										{
											if (num423 != this.whoAmI && Main.npc[num423].active && (Main.npc[num423].type == 125 || Main.npc[num423].type == 126) && Main.npc[num423].timeLeft - 1 > this.timeLeft)
											{
												this.timeLeft = Main.npc[num423].timeLeft - 1;
											}
											num = num423;
										}
									}
									if (Main.dayTime | dead3)
									{
										this.velocity.Y = this.velocity.Y - 0.04f;
										if (this.timeLeft > 10)
										{
											this.timeLeft = 10;
											return;
										}
									}
									else if (this.ai[0] == 0f)
									{
										if (this.ai[1] == 0f)
										{
											this.TargetClosest(true);
											float num424 = 12f;
											float num425 = 0.4f;
											int num426 = 1;
											if (this.position.X + (float)(this.width / 2) < Main.player[this.target].position.X + (float)Main.player[this.target].width)
											{
												num426 = -1;
											}
											Vector2 vector44 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											float num427 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) + (float)(num426 * 400) - vector44.X;
											float num428 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector44.Y;
											float num429 = (float)Math.Sqrt((double)(num427 * num427 + num428 * num428));
											num429 = num424 / num429;
											num427 *= num429;
											num428 *= num429;
											if (this.velocity.X < num427)
											{
												this.velocity.X = this.velocity.X + num425;
												if (this.velocity.X < 0f && num427 > 0f)
												{
													this.velocity.X = this.velocity.X + num425;
												}
											}
											else if (this.velocity.X > num427)
											{
												this.velocity.X = this.velocity.X - num425;
												if (this.velocity.X > 0f && num427 < 0f)
												{
													this.velocity.X = this.velocity.X - num425;
												}
											}
											if (this.velocity.Y < num428)
											{
												this.velocity.Y = this.velocity.Y + num425;
												if (this.velocity.Y < 0f && num428 > 0f)
												{
													this.velocity.Y = this.velocity.Y + num425;
												}
											}
											else if (this.velocity.Y > num428)
											{
												this.velocity.Y = this.velocity.Y - num425;
												if (this.velocity.Y > 0f && num428 < 0f)
												{
													this.velocity.Y = this.velocity.Y - num425;
												}
											}
											this.ai[2] += 1f;
											if (this.ai[2] >= 600f)
											{
												this.ai[1] = 1f;
												this.ai[2] = 0f;
												this.ai[3] = 0f;
												this.target = 255;
												this.netUpdate = true;
											}
											else
											{
												if (!Main.player[this.target].dead)
												{
													this.ai[3] += 1f;
													if (Main.expertMode && (double)this.life < (double)this.lifeMax * 0.8)
													{
														this.ai[3] += 0.6f;
													}
												}
												if (this.ai[3] >= 60f)
												{
													this.ai[3] = 0f;
													vector44 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
													num427 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector44.X;
													num428 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector44.Y;
													if (Main.netMode != 1)
													{
														float num430 = 12f;
														int num431 = 25;
														int num432 = 96;
														if (Main.expertMode)
														{
															num430 = 14f;
															num431 = 22;
														}
														num429 = (float)Math.Sqrt((double)(num427 * num427 + num428 * num428));
														num429 = num430 / num429;
														num427 *= num429;
														num428 *= num429;
														num427 += (float)Main.rand.Next(-40, 41) * 0.05f;
														num428 += (float)Main.rand.Next(-40, 41) * 0.05f;
														vector44.X += num427 * 4f;
														vector44.Y += num428 * 4f;
														int num433 = Projectile.NewProjectile(vector44.X, vector44.Y, num427, num428, num432, num431, 0f, Main.myPlayer, 0f, 0f);
													}
												}
											}
										}
										else if (this.ai[1] == 1f)
										{
											this.rotation = num420;
											float num434 = 13f;
											if (Main.expertMode)
											{
												if ((double)this.life < (double)this.lifeMax * 0.9)
												{
													num434 += 0.5f;
												}
												if ((double)this.life < (double)this.lifeMax * 0.8)
												{
													num434 += 0.5f;
												}
												if ((double)this.life < (double)this.lifeMax * 0.7)
												{
													num434 += 0.55f;
												}
												if ((double)this.life < (double)this.lifeMax * 0.6)
												{
													num434 += 0.6f;
												}
												if ((double)this.life < (double)this.lifeMax * 0.5)
												{
													num434 += 0.65f;
												}
											}
											Vector2 vector45 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											float num435 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector45.X;
											float num436 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector45.Y;
											float num437 = (float)Math.Sqrt((double)(num435 * num435 + num436 * num436));
											num437 = num434 / num437;
											this.velocity.X = num435 * num437;
											this.velocity.Y = num436 * num437;
											this.ai[1] = 2f;
										}
										else if (this.ai[1] == 2f)
										{
											this.ai[2] += 1f;
											if (this.ai[2] >= 8f)
											{
												this.velocity.X = this.velocity.X * 0.9f;
												this.velocity.Y = this.velocity.Y * 0.9f;
												if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
												{
													this.velocity.X = 0f;
												}
												if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
												{
													this.velocity.Y = 0f;
												}
											}
											else
											{
												this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
											}
											if (this.ai[2] >= 42f)
											{
												this.ai[3] += 1f;
												this.ai[2] = 0f;
												this.target = 255;
												this.rotation = num420;
												if (this.ai[3] >= 10f)
												{
													this.ai[1] = 0f;
													this.ai[3] = 0f;
												}
												else
												{
													this.ai[1] = 1f;
												}
											}
										}
										if ((double)this.life < (double)this.lifeMax * 0.4)
										{
											this.ai[0] = 1f;
											this.ai[1] = 0f;
											this.ai[2] = 0f;
											this.ai[3] = 0f;
											this.netUpdate = true;
											return;
										}
									}
									else if (this.ai[0] == 1f || this.ai[0] == 2f)
									{
										if (this.ai[0] == 1f)
										{
											this.ai[2] += 0.005f;
											if ((double)this.ai[2] > 0.5)
											{
												this.ai[2] = 0.5f;
											}
										}
										else
										{
											this.ai[2] -= 0.005f;
											if (this.ai[2] < 0f)
											{
												this.ai[2] = 0f;
											}
										}
										this.rotation += this.ai[2];
										this.ai[1] += 1f;
										if (this.ai[1] == 100f)
										{
											this.ai[0] += 1f;
											this.ai[1] = 0f;
											if (this.ai[0] == 3f)
											{
												this.ai[2] = 0f;
											}
											else
											{
												Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 1, 1f, 0f);
												int num;
												for (int num438 = 0; num438 < 2; num438 = num + 1)
												{
													Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 144, 1f);
													Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
													Gore.NewGore(this.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
													num = num438;
												}
												for (int num439 = 0; num439 < 20; num439 = num + 1)
												{
													Dust.NewDust(this.position, this.width, this.height, 5, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
													num = num439;
												}
												Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0, 1f, 0f);
											}
										}
										Dust.NewDust(this.position, this.width, this.height, 5, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
										this.velocity.X = this.velocity.X * 0.98f;
										this.velocity.Y = this.velocity.Y * 0.98f;
										if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
										{
											this.velocity.X = 0f;
										}
										if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
										{
											this.velocity.Y = 0f;
											return;
										}
									}
									else
									{
										this.HitSound = SoundID.NPCHit4;
										this.damage = (int)((double)this.defDamage * 1.5);
										this.defense = this.defDefense + 18;
										if (this.ai[1] == 0f)
										{
											float num440 = 4f;
											float num441 = 0.1f;
											int num442 = 1;
											if (this.position.X + (float)(this.width / 2) < Main.player[this.target].position.X + (float)Main.player[this.target].width)
											{
												num442 = -1;
											}
											Vector2 vector46 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
											float num443 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) + (float)(num442 * 180) - vector46.X;
											float num444 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector46.Y;
											float num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
											if (Main.expertMode)
											{
												if (num445 > 300f)
												{
													num440 += 0.5f;
												}
												if (num445 > 400f)
												{
													num440 += 0.5f;
												}
												if (num445 > 500f)
												{
													num440 += 0.55f;
												}
												if (num445 > 600f)
												{
													num440 += 0.55f;
												}
												if (num445 > 700f)
												{
													num440 += 0.6f;
												}
												if (num445 > 800f)
												{
													num440 += 0.6f;
												}
											}
											num445 = num440 / num445;
											num443 *= num445;
											num444 *= num445;
											if (this.velocity.X < num443)
											{
												this.velocity.X = this.velocity.X + num441;
												if (this.velocity.X < 0f && num443 > 0f)
												{
													this.velocity.X = this.velocity.X + num441;
												}
											}
											else if (this.velocity.X > num443)
											{
												this.velocity.X = this.velocity.X - num441;
												if (this.velocity.X > 0f && num443 < 0f)
												{
													this.velocity.X = this.velocity.X - num441;
												}
											}
											if (this.velocity.Y < num444)
											{
												this.velocity.Y = this.velocity.Y + num441;
												if (this.velocity.Y < 0f && num444 > 0f)
												{
													this.velocity.Y = this.velocity.Y + num441;
												}
											}
											else if (this.velocity.Y > num444)
											{
												this.velocity.Y = this.velocity.Y - num441;
												if (this.velocity.Y > 0f && num444 < 0f)
												{
													this.velocity.Y = this.velocity.Y - num441;
												}
											}
											this.ai[2] += 1f;
											if (this.ai[2] >= 400f)
											{
												this.ai[1] = 1f;
												this.ai[2] = 0f;
												this.ai[3] = 0f;
												this.target = 255;
												this.netUpdate = true;
											}
											if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
											{
												this.localAI[2] += 1f;
												if (this.localAI[2] > 22f)
												{
													this.localAI[2] = 0f;
													Main.PlaySound(SoundID.Item34, this.position);
												}
												if (Main.netMode != 1)
												{
													this.localAI[1] += 1f;
													if ((double)this.life < (double)this.lifeMax * 0.75)
													{
														this.localAI[1] += 1f;
													}
													if ((double)this.life < (double)this.lifeMax * 0.5)
													{
														this.localAI[1] += 1f;
													}
													if ((double)this.life < (double)this.lifeMax * 0.25)
													{
														this.localAI[1] += 1f;
													}
													if ((double)this.life < (double)this.lifeMax * 0.1)
													{
														this.localAI[1] += 2f;
													}
													if (this.localAI[1] > 8f)
													{
														this.localAI[1] = 0f;
														float num446 = 6f;
														int num447 = 30;
														if (Main.expertMode)
														{
															num447 = 27;
														}
														int num448 = 101;
														vector46 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
														num443 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector46.X;
														num444 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector46.Y;
														num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
														num445 = num446 / num445;
														num443 *= num445;
														num444 *= num445;
														num444 += (float)Main.rand.Next(-40, 41) * 0.01f;
														num443 += (float)Main.rand.Next(-40, 41) * 0.01f;
														num444 += this.velocity.Y * 0.5f;
														num443 += this.velocity.X * 0.5f;
														vector46.X -= num443 * 1f;
														vector46.Y -= num444 * 1f;
														int num449 = Projectile.NewProjectile(vector46.X, vector46.Y, num443, num444, num448, num447, 0f, Main.myPlayer, 0f, 0f);
														return;
													}
												}
											}
										}
										else
										{
											if (this.ai[1] == 1f)
											{
												Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0, 1f, 0f);
												this.rotation = num420;
												float num450 = 14f;
												if (Main.expertMode)
												{
													num450 += 2.5f;
												}
												Vector2 vector47 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
												float num451 = Main.player[this.target].position.X + (float)(Main.player[this.target].width / 2) - vector47.X;
												float num452 = Main.player[this.target].position.Y + (float)(Main.player[this.target].height / 2) - vector47.Y;
												float num453 = (float)Math.Sqrt((double)(num451 * num451 + num452 * num452));
												num453 = num450 / num453;
												this.velocity.X = num451 * num453;
												this.velocity.Y = num452 * num453;
												this.ai[1] = 2f;
												return;
											}
											if (this.ai[1] == 2f)
											{
												this.ai[2] += 1f;
												if (Main.expertMode)
												{
													this.ai[2] += 0.5f;
												}
												if (this.ai[2] >= 50f)
												{
													this.velocity.X = this.velocity.X * 0.93f;
													this.velocity.Y = this.velocity.Y * 0.93f;
													if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
													{
														this.velocity.X = 0f;
													}
													if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
													{
														this.velocity.Y = 0f;
													}
												}
												else
												{
													this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 1.57f;
												}
												if (this.ai[2] >= 80f)
												{
													this.ai[3] += 1f;
													this.ai[2] = 0f;
													this.target = 255;
													this.rotation = num420;
													if (this.ai[3] >= 6f)
													{
														this.ai[1] = 0f;
														this.ai[3] = 0f;
														return;
													}
													this.ai[1] = 1f;
													return;
												}
											}
										}
									}
								}*/