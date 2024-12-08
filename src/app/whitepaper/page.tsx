"use client";

import { useState } from 'react';
import { Righteous, Fredoka } from 'next/font/google';

const righteous = Righteous({
  subsets: ['latin'],
  weight: "400"
});

const fredoka = Fredoka({
  subsets: ['latin'],
  weight: ["400", "600", "700"],
});

export default function WhitePaper() {
  const [activeSection, setActiveSection] = useState('introduction');

  const sections = [
    { 
      id: 'introduction', 
      title: '👋 Introduction', 
      subsections: ['Game Overview', 'Vision & Mission', 'Market Analysis'] 
    },
    { 
      id: 'gameplay', 
      title: '🎮 Gameplay', 
      subsections: ['Season System', 'Farm Mechanism', 'Gacha System', 'Scoring System'] 
    },
    { 
      id: 'nftSystem', 
      title: '🖼️ NFT System', 
      subsections: ['NFT Types', 'NFT Benefits', 'Trading System'] 
    },
    { 
      id: 'tokenomics', 
      title: '💰 Tokenomics', 
      subsections: ['HUFA Token', 'Pool Distribution', 'Token Utility'] 
    },
    { 
      id: 'technology', 
      title: '🔧 Technology', 
      subsections: ['Platform Architecture', 'Blockchain Integration'] 
    },
    { 
      id: 'rewards', 
      title: '🏆 Rewards', 
      subsections: ['Ranking System', 'Pool Rewards', 'NFT Rewards'] 
    }
  ];

  return (
    <div className={`flex min-h-screen w-screen ${righteous.className}`}>
      {/* Sidebar */}
      <div className="w-72 bg-green-800 text-white fixed h-full overflow-y-auto">
        <div className="p-6">
          <h2 className={`text-2xl font-bold mb-8 ${fredoka.className}`}>
            HustleFarm Whitepaper
          </h2>
          <nav>
            {sections.map((section) => (
              <div key={section.id} className="mb-6">
                <button
                  onClick={() => setActiveSection(section.id)}
                  className={`w-full text-left p-3 rounded-lg transition-colors duration-200 font-semibold
                    ${activeSection === section.id 
                      ? 'bg-green-700 text-yellow-300' 
                      : 'hover:bg-green-700/50'}`}
                >
                  {section.title}
                </button>
                <div className="ml-4 mt-2 space-y-1">
                  {section.subsections.map((subsection) => (
                    <button
                      key={subsection}
                      className="w-full text-left p-2 text-sm hover:text-yellow-200 transition-colors"
                    >
                      {subsection}
                    </button>
                  ))}
                </div>
              </div>
            ))}
          </nav>
        </div>
      </div>

      {/* Main Content */}
      <div className="ml-72 flex-1 bg-gradient-to-b from-green-50 to-yellow-50 min-h-screen">
        <div className="max-w-4xl mx-auto p-8">
          <div className="bg-white rounded-xl p-8">
            {/* Header */}
            <div className="mb-12 text-center border-b pb-8">
              <h1 className={`text-4xl font-bold text-green-800 mb-4 ${fredoka.className}`}>
                HustleFarm Whitepaper
              </h1>
              <p className="text-gray-600">Version 1.0.1 - Last updated March 2024</p>
            </div>

            {/* Content */}
            <div className="space-y-12">
              {/* Abstract */}
              <section>
                <h2 className={`text-3xl font-bold text-green-800 mb-6 ${fredoka.className}`}>
                  Abstract
                </h2>
                <div className="space-y-4 text-gray-800 leading-relaxed">
                  <p>
                    HustleFarm represents a revolutionary approach to blockchain gaming, combining engaging farming simulation with play-to-earn mechanics. Our platform creates a unique digital ecosystem where players can own virtual farmland, cultivate crops, raise livestock, and participate in a dynamic player-driven economy.
                  </p>
                  <p>
                    Built on blockchain technology, HustleFarm ensures true ownership of in-game assets through NFTs while providing players with meaningful ways to earn rewards through active participation and strategic gameplay.
                  </p>
                </div>
              </section>

              {/* Game Overview */}
              <section>
                <h2 className={`text-3xl font-bold text-green-800 mb-6 ${fredoka.className}`}>
                  Game Overview
                </h2>
                <div className="space-y-4 text-gray-800 leading-relaxed">
                  <p>
                    HustleFarm là một game NFT Play-to-Earn sáng tạo, kết hợp những điểm mạnh từ các tựa game nông trại thành công và khắc phục các điểm yếu. Game được xây dựng trên nền tảng Unity với tích hợp blockchain, mang đến trải nghiệm farming độc đáo kết hợp với cơ chế Play-to-Earn.
                  </p>
                  <div className="grid md:grid-cols-2 gap-8 mt-6">
                    <div className="bg-green-50 rounded-lg p-6">
                      <h3 className="text-xl font-semibold text-green-700 mb-4">Key Features</h3>
                      <ul className="space-y-3">
                        <li className="flex items-start">
                          <span className="text-green-600 mr-2">🌾</span>
                          <span>Hệ thống Farm với nhiều loại cây trồng độc đáo</span>
                        </li>
                        <li className="flex items-start">
                          <span className="text-green-600 mr-2">🎲</span>
                          <span>Gacha system với tỷ lệ rõ ràng</span>
                        </li>
                        <li className="flex items-start">
                          <span className="text-green-600 mr-2">🏆</span>
                          <span>Season rewards hấp dẫn mỗi 14 ngày</span>
                        </li>
                      </ul>
                    </div>
                    <div className="bg-green-50 rounded-lg p-6">
                      <h3 className="text-xl font-semibold text-green-700 mb-4">Token & Trading</h3>
                      <ul className="space-y-3">
                        <li className="flex items-start">
                          <span className="text-green-600 mr-2">💎</span>
                          <span>NFT trading trên sàn OKX</span>
                        </li>
                        <li className="flex items-start">
                          <span className="text-green-600 mr-2">🪙</span>
                          <span>Token HUFA giao dịch trên PancakeSwap</span>
                        </li>
                        <li className="flex items-start">
                          <span className="text-green-600 mr-2">🔄</span>
                          <span>Thirdweb API integration đảm bảo an toàn</span>
                        </li>
                      </ul>
                    </div>
                  </div>
                </div>
              </section>

              {/* Gameplay Mechanics */}
              <section>
                <h2 className={`text-3xl font-bold text-green-800 mb-6 ${fredoka.className}`}>
                  Gameplay Mechanics
                </h2>
                <div className="space-y-6 text-gray-800 leading-relaxed">
                  <div className="bg-green-50 rounded-lg p-6">
                    <h3 className="text-xl font-semibold text-green-700 mb-4">Season System</h3>
                    <ul className="list-disc pl-5 space-y-2">
                      <li>Mỗi season kéo dài 14 ngày</li>
                      <li>Tổng pool ban đầu: 10,000 HUFA token</li>
                      <li>Pool tăng theo số lượng Gacha được sử dụng</li>
                    </ul>
                  </div>
                  
                  <div className="grid md:grid-cols-2 gap-6">
                    <div className="bg-green-50 rounded-lg p-6">
                      <h3 className="text-xl font-semibold text-green-700 mb-4">Farm System</h3>
                      <div className="overflow-x-auto">
                        <table className="min-w-full">
                          <thead>
                            <tr className="border-b">
                              <th className="text-left py-2">Cây</th>
                              <th className="text-left py-2">Loại</th>
                              <th className="text-left py-2">Ngày</th>
                              <th className="text-left py-2">Điểm/Ngày</th>
                            </tr>
                          </thead>
                          <tbody className="text-sm">
                            <tr>
                              <td>Cây 1</td>
                              <td>Common</td>
                              <td>14</td>
                              <td>1</td>
                            </tr>
                            {/* Thêm các cây khác */}
                          </tbody>
                        </table>
                      </div>
                    </div>

                    <div className="bg-green-50 rounded-lg p-6">
                      <h3 className="text-xl font-semibold text-green-700 mb-4">Gacha System</h3>
                      <div className="space-y-2">
                        <p className="font-semibold">Tỷ lệ xuất hiện:</p>
                        <ul className="space-y-2">
                          <li className="flex justify-between">
                            <span>Common</span>
                            <span>50% (1 điểm)</span>
                          </li>
                          <li className="flex justify-between">
                            <span>Rare</span>
                            <span>35% (2 điểm)</span>
                          </li>
                          <li className="flex justify-between">
                            <span>Epic</span>
                            <span>10% (5 điểm)</span>
                          </li>
                          <li className="flex justify-between">
                            <span>Legend</span>
                            <span>5% (10 điểm)</span>
                          </li>
                        </ul>
                      </div>
                    </div>
                  </div>
                </div>
              </section>

              {/* Blockchain Integration */}
              <section>
                <h2 className={`text-3xl font-bold text-green-800 mb-6 ${fredoka.className}`}>
                  Blockchain Integration
                </h2>
                <div className="space-y-6 text-gray-800 leading-relaxed">
                  <div className="bg-green-50 rounded-lg p-6">
                    <h3 className="text-xl font-semibold text-green-700 mb-4">NFT Assets</h3>
                    <div className="grid md:grid-cols-2 gap-6">
                      <div>
                        <h4 className="font-semibold mb-2">Land NFTs</h4>
                        <ul className="list-disc pl-5 space-y-2">
                          <li>Unique plot locations</li>
                          <li>Different soil types</li>
                          <li>Upgradeable facilities</li>
                          <li>Resource generation</li>
                        </ul>
                      </div>
                      <div>
                        <h4 className="font-semibold mb-2">Game Items</h4>
                        <ul className="list-disc pl-5 space-y-2">
                          <li>Farming tools</li>
                          <li>Rare seeds</li>
                          <li>Special animals</li>
                          <li>Decorative items</li>
                        </ul>
                      </div>
                    </div>
                  </div>
                </div>
              </section>

              {/* Tokenomics */}
              <section>
                <h2 className={`text-3xl font-bold text-green-800 mb-6 ${fredoka.className}`}>
                  Tokenomics
                </h2>
                <div className="grid md:grid-cols-2 gap-8 text-gray-800 leading-relaxed">
                  <div className="bg-green-50 rounded-lg p-6">
                    <h3 className="text-xl font-semibold text-green-700 mb-4">Token Distribution</h3>
                    <ul className="space-y-3">
                      <li className="flex justify-between">
                        <span>Player Rewards</span>
                        <span className="font-semibold">40%</span>
                      </li>
                      <li className="flex justify-between">
                        <span>Development</span>
                        <span className="font-semibold">20%</span>
                      </li>
                      <li className="flex justify-between">
                        <span>Marketing</span>
                        <span className="font-semibold">15%</span>
                      </li>
                      <li className="flex justify-between">
                        <span>Team</span>
                        <span className="font-semibold">15%</span>
                      </li>
                      <li className="flex justify-between">
                        <span>Reserve</span>
                        <span className="font-semibold">10%</span>
                      </li>
                    </ul>
                  </div>
                  <div className="bg-green-50 rounded-lg p-6">
                    <h3 className="text-xl font-semibold text-green-700 mb-4">Token Utility</h3>
                    <ul className="space-y-3">
                      <li className="flex items-start">
                        <span className="text-green-600 mr-2">💰</span>
                        <span>In-game purchases</span>
                      </li>
                      <li className="flex items-start">
                        <span className="text-green-600 mr-2">🎮</span>
                        <span>Gameplay rewards</span>
                      </li>
                      <li className="flex items-start">
                        <span className="text-green-600 mr-2">🏷️</span>
                        <span>NFT minting</span>
                      </li>
                      <li className="flex items-start">
                        <span className="text-green-600 mr-2">🤝</span>
                        <span>Governance voting</span>
                      </li>
                    </ul>
                  </div>
                </div>
              </section>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
